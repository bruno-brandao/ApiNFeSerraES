using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class TakerController : MasterController
    {
        private List<Takers> lTakers = new List<Takers>();

        public JsonResult Select()
        {
            try
            {
                //...
                SQL.AppendLine("  ");
                SQL.AppendLine("  ");
                SQL.AppendLine("  ");
                SQL.AppendLine("  ");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0 )
                {
                    foreach (DataRow drTaker in data.Rows)
                    {
                        Takers taker = new Takers();
                        taker.TakerId = drTaker("TakerId");
                        //......
                        lTakers.Add(taker);
                    }
                    return Json(lTakers, JsonRequestBehavior.AllowGet);
                }
                return new JsonResult(new Feedback("erro", "Não foram encontrados registros!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }            
        }

        public JsonResult Insert()
        {
            try
            {
                return new JsonResult();
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }            
        }

        public JsonResult Update()
        {
            try
            {
                return new JsonResult();
            }
            catch (Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete()
        {
            try
            {
                return new JsonResult();
            }
            catch (Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }        
    }
}