using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Domain
{
    public class TaxpayerActivitiesDomain : MasterDomain
    {
        public bool Reload(string CPF,
            string Password,
            string IM,
            int CodeCity,
            long CompanyId)            
        {
            try
            {              
                if (CompanyId > 0 && new CompanyDomain().Select(CompanyId).Count() <= 0)
                {
                    throw new Exception("Empresa inválida!");
                }

                WSEntrada.WSEntrada Entrada = new WSEntrada.WSEntradaClient();
                WSEntrada.consultarAtividadesRequest Request = new WSEntrada.consultarAtividadesRequest();
                WSEntrada.consultarAtividadesRequestBody Body = new WSEntrada.consultarAtividadesRequestBody();

                Body.cpfUsuario = CPF;
                Body.hashSenha = Password;
                Body.inscricaoMunicipal = IM;
                Body.codigoMunicipio = CodeCity;
                Request.Body = Body;

                WSEntrada.consultarAtividadesResponse ApiResponse = Entrada.consultarAtividades(Request);

                string TaxpayerActivities = ApiResponse.Body.@return;
                if (IsXml(TaxpayerActivities))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AtividadesContribuinte));
                    StringReader stringReader = new StringReader(TaxpayerActivities);
                    AtividadesContribuinte atividadesContribuinte = (AtividadesContribuinte)xmlSerializer.Deserialize(stringReader);
                    if (atividadesContribuinte.Atividade.Count() > 0)
                    {

                        foreach (Atividade atividade in atividadesContribuinte.Atividade)
                        {
                            SQL = new StringBuilder();
                            SQL.AppendLine(" Insert Into TaxpayerActivities ");
                            SQL.AppendLine("    ( ");
                            SQL.AppendLine("        CompanyId, ");
                            SQL.AppendLine("        CNAE, ");
                            SQL.AppendLine("        Description, ");
                            SQL.AppendLine("        Aliquot, ");
                            SQL.AppendLine("        Active, ");
                            SQL.AppendLine("        DateInsert, ");
                            SQL.AppendLine("        DateUpdate ");
                            SQL.AppendLine("    ) ");
                            SQL.AppendLine(" Values ");
                            SQL.AppendLine("    ( ");
                            SQL.AppendLine("      " + CompanyId + ",");
                            SQL.AppendLine("      '" + NoInjection(atividade.CodigoCnae) + "', ");
                            SQL.AppendLine("      '" + NoInjection(atividade.Descricao) + "', ");
                            SQL.AppendLine("       " + FormatNumber(decimal.Parse((atividade.Aliquota == string.Empty ? "0" : atividade.Aliquota))) + ", ");
                            SQL.AppendLine("       1, ");
                            SQL.AppendLine("       Getdate(), ");
                            SQL.AppendLine("       Getdate() ");
                            SQL.AppendLine("    ) ");

                            Conn.Insert(SQL.ToString());
                        }
                        return true;
                    }
                    throw new Exception("Não foram encontradas atividades do contribuinte!");
                }
                throw new Exception(TaxpayerActivities);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<TaxpayerActivities> Select(string CPF,
            string Password,
            string IM,
            int CodeCity,
            long CompanyId)
        {
            try
            {
                List<TaxpayerActivities> lTaxpayerActivities = new List<TaxpayerActivities>();

                SQL = new StringBuilder();
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    TaxpayerActivitiesId, ");
                SQL.AppendLine("    CompanyId, ");
                SQL.AppendLine("    CNAE, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    Aliquot, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From TaxpayerActivities ");
                SQL.AppendLine(" Where Active = 1 ");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "TaxpayerActivities");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        TaxpayerActivities taxpayerActivities = new TaxpayerActivities();
                        taxpayerActivities.TaxpayerActivitiesId = long.Parse(row["TaxpayerActivitiesId"].ToString());
                        taxpayerActivities.CompanyId = long.Parse(row["CompanyId"].ToString());
                        taxpayerActivities.CNAE = row["CNAE"].ToString();
                        taxpayerActivities.Description = row["Description"].ToString();
                        taxpayerActivities.Aliquot = decimal.Parse(row["Aliquot"].ToString());
                        taxpayerActivities.Active = bool.Parse(row["Active"].ToString());
                        taxpayerActivities.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        taxpayerActivities.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lTaxpayerActivities.Add(taxpayerActivities);
                    }
                    return lTaxpayerActivities;
                }
                throw new Exception("Não foram encontrados registros!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}