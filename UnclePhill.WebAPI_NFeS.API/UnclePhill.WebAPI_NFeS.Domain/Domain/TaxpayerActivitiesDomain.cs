using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Domain.Domain;
using UnclePhill.WebAPI_NFeS.Domain.NFeS.API.Serra.Entrada;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Models.Models;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSStructure.NFeSTaxpayerActivities;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.Domain
{
    public class TaxpayerActivitiesDomain : DefaultDomains.MasterDomain
    {
        public void Reload(string CPF,
            string Password,
            string IM,
            int CodeCity,
            long CompanyId)            
        {
            try
            {
                Validate(CompanyId);
                Companys Company = new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company, CompanyId);                
                string TaxpayerActivities = API.GetActivities(API.GetCity(Company.City),CPF, Password, IM, CodeCity);

                if (Functions.XmlFunctions.IsXml(TaxpayerActivities))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AtividadesContribuinte));
                    StringReader stringReader = new StringReader(TaxpayerActivities);
                    AtividadesContribuinte atividadesContribuinte = (AtividadesContribuinte)xmlSerializer.Deserialize(stringReader);
                    if (atividadesContribuinte.Atividade.Count() > 0)
                    {
                        try
                        {
                            List<TaxpayerActivities> ltaxpayerActivities = GetByCompany(CompanyId);
                            foreach (TaxpayerActivities taxpayerActivities in ltaxpayerActivities)
                            {
                                Delete(taxpayerActivities.TaxpayerActivitiesId);
                            }
                        }
                        catch
                        {
                        }
                        
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
                            SQL.AppendLine("      '" + Functions.NoQuote(atividade.CodigoCnae) + "', ");
                            SQL.AppendLine("      '" + Functions.NoQuote(atividade.Descricao) + "', ");
                            SQL.AppendLine("       " + Functions.FormatNumber(decimal.Parse((atividade.Aliquota == string.Empty ? "0" : atividade.Aliquota))) + ", ");
                            SQL.AppendLine("       1, ");
                            SQL.AppendLine("       Getdate(), ");
                            SQL.AppendLine("       Getdate() ");
                            SQL.AppendLine("    ) ");

                            Functions.Conn.Insert(SQL.ToString());
                        }
                    }
                    else
                    {
                        throw new InternalProgramException("Não foram encontradas atividades do contribuinte!");
                    }
                }
                else
                {
                    throw new InternalProgramException(TaxpayerActivities);
                }                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<TaxpayerActivities> GetByCompany(long CompanyId = 0)
        {
            try
            {
                Validate(CompanyId);

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
                SQL.AppendLine(" And CompanyId = " + CompanyId);

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "TaxpayerActivities");
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
                throw new InternalProgramException("Não foram encontrados registros!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaxpayerActivities Get(long TaxpayerActivitiesId = 0)
        {
            try
            {
                if (TaxpayerActivitiesId <= 0)
                {
                    throw new InternalProgramException("Informe a atividade!");
                }

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
                SQL.AppendLine(" And TaxpayerActivitiesId = " + TaxpayerActivitiesId);

                DataTable data = Functions.Conn.GetDataTable(SQL.ToString(), "TaxpayerActivities");
                if (data != null && data.Rows.Count > 0)
                {
                    var row = data.AsEnumerable().First();
                    TaxpayerActivities taxpayerActivities = new TaxpayerActivities();
                    taxpayerActivities.TaxpayerActivitiesId = long.Parse(row["TaxpayerActivitiesId"].ToString());
                    taxpayerActivities.CompanyId = long.Parse(row["CompanyId"].ToString());
                    taxpayerActivities.CNAE = row["CNAE"].ToString();
                    taxpayerActivities.Description = row["Description"].ToString();
                    taxpayerActivities.Aliquot = decimal.Parse(row["Aliquot"].ToString());
                    taxpayerActivities.Active = bool.Parse(row["Active"].ToString());
                    taxpayerActivities.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                    taxpayerActivities.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");

                    return taxpayerActivities;
                }
                throw new InternalProgramException("Não foram encontrados registros!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long TaxpayerActivitiesId = 0)
        {
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine(" Delete From TaxpayerActivities ");
                SQL.AppendLine(" Where TaxpayerActivitiesId = " + TaxpayerActivitiesId);

                return Functions.Conn.Delete(SQL.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
               
        private void Validate(long CompanyId = 0)
        {
            if (CompanyId <= 0)
            {
                throw new InternalProgramException("Informe a empresa!");
            }

            if (new CompanyDomain().Get<Companys>(CompanyDomain.Type.Company, CompanyId).CompanyId <= 0)
            {
                throw new InternalProgramException("A empresa informada não existe na base de dados.");
            }
        }
    }
}