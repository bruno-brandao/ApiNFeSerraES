using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class TaxpayerActivitiesController : MasterController
    {
        [HttpPost]
        public JsonResult Insert(string CPF = "55555555555", 
            string Password = "cRDtpNCeBiql5KOQsKVyrA0sAiA=", 
            string IM = "4546565", 
            int CodeCity = 3, 
            long CompanyId = 0)
        {
            try
            {
                //Homologação Serra:
                //cpfUsuario:55555555555
                //hashSenha: cRDtpNCeBiql5KOQsKVyrA0sAiA=
                //inscricaoMunicipal = 4546565
                //codigoMunicipio = 3
                              
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
                    foreach(Atividade atividade in atividadesContribuinte.Atividade)
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
                        SQL.AppendLine("      1,");
                        SQL.AppendLine("      '" + NoInjection(atividade.CodigoCnae) + "', ");
                        SQL.AppendLine("      '" + NoInjection(atividade.Descricao) + "', ");
                        SQL.AppendLine("       " + FormatNumber(decimal.Parse((atividade.Aliquota == string.Empty? "0" : atividade.Aliquota))) + ", ");
                        SQL.AppendLine("       1, ");
                        SQL.AppendLine("       Getdate(), ");
                        SQL.AppendLine("       Getdate() ");
                        SQL.AppendLine("    ) ");

                        Conn.Insert(SQL.ToString());
                    }
                }             
                return Response(new Feedbacks("ok", "Sucesso"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));              
            }
        }
    }
}