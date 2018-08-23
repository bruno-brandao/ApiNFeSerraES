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
    public class ServiceController : MasterController
    {
        public JsonResult Select(long? ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                List<Services> lServices = new List<Services>();

                SQL.AppendLine(" Select ");
                SQL.AppendLine("    ServicesId, ");
                SQL.AppendLine("    Unity, ");
                SQL.AppendLine("    Value, ");
                SQL.AppendLine("    Description, ");
                SQL.AppendLine("    IRRF, ");
                SQL.AppendLine("    PIS, ");
                SQL.AppendLine("    CSLL, ");
                SQL.AppendLine("    INSS, ");
                SQL.AppendLine("    COFINS, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate ");
                SQL.AppendLine(" From Services ");
                SQL.AppendLine(" Where Active = 1 ");
                if (ServicesId > 0) { SQL.AppendLine(" And ServicesId = " + ServicesId); }
                
                DataTable data = Conn.GetDataTable(SQL.ToString(), "Services");
                if (data != null && data.Rows.Count > 0)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        Services service = new Services();
                        service.ServicesId = long.Parse(row["ServicesId"].ToString());
                        service.Unity = row["Unity"].ToString();
                        service.Value = decimal.Parse(row["Value"].ToString());
                        service.Description = row["Description"].ToString();
                        service.IRRF = decimal.Parse(row["IRRF"].ToString());
                        service.PIS = decimal.Parse(row["PIS"].ToString());
                        service.CSLL = decimal.Parse(row["CSLL"].ToString());
                        service.INSS = decimal.Parse(row["INSS"].ToString());
                        service.COFINS = decimal.Parse(row["COFINS"].ToString());
                        service.Active = bool.Parse(row["Active"].ToString());
                        service.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                        service.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                        lServices.Add(service);
                    }
                    return Response(lServices);
                }
                return Response(new Feedbacks("erro", "Não foram encontrados registros!"));
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Insert(Services services)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Update(Services services)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Delete(long ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        private Feedbacks Validate()
        {
            return new Feedbacks("ok","Sucesso");
        }
    }
}