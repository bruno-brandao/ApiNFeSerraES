using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class CFPSController : MasterController
    {
        [HttpGet]
        public JsonResult Select(long? CFPSId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                List<CFPS> lCFPS = new List<CFPS>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    CFPSId, ");
                SQL.AppendLine("    CFPS, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From CFPS ");
                SQL.AppendLine(" Where Active = 1 ");
                if (CFPSId > 0) { SQL.AppendLine(" And CFPSId = " + CFPSId); }


                DataTable data = Conn.GetDataTable(SQL.ToString(), "CFPS");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        CFPS CFPS = new CFPS();
                        CFPS.CFPSId = long.Parse(row["CFPSId"].ToString());
                        CFPS.CFPSCod = row["CFPS"].ToString();
                        CFPS.Description = row["Description"].ToString();
                        CFPS.Active = bool.Parse(row["Active"].ToString());
                        CFPS.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        CFPS.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lCFPS.Add(CFPS);
                    }
                    return Response(lCFPS);
                }
                return Response(new Feedbacks("erro", "Não foram encontrados registros!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpGet]
        public JsonResult SelectCodigoContribuinte()
        {
            try
            {
                WSEntrada.WSEntrada Entrada = new WSEntrada.WSEntradaClient();
                WSEntrada.consultarAtividadesRequest Request = new WSEntrada.consultarAtividadesRequest();
                Request.Body = new WSEntrada.consultarAtividadesRequestBody();
                Request.Body.cpfUsuario = "555.555.555-55";
                Request.Body.inscricaoMunicipal = "99999";
                Request.Body.hashSenha = "cRDtpNCeBiql5KOQsKVyrA0sAiA=";                
                Request.Body.codigoMunicipio = 3;        

                WSEntrada.consultarAtividadesResponse ApiResponse = Entrada.consultarAtividades(Request);

                return Response(new Feedbacks("ok", ApiResponse.Body.@return));
            }catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }
    }
}   