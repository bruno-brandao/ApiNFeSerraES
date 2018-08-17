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
    public class TakerController : MasterController
    {
        private List<Takers> lTakers = new List<Takers>();

        public JsonResult Select()
        {
            try
            {
                SQL.AppendLine(" Select ");
                SQL.AppendLine("    Takers.TakerId ");
                SQL.AppendLine(" From Takers ");
                
                DataTable data = Conn.GetDataTable(SQL.ToString(), "Takers");
                if (data != null && data.Rows.Count > 0 )
                {
                    foreach (DataRow drTaker in data.Rows)
                    {
                        Takers taker = new Takers();
                        taker.TakerId = long.Parse(drTaker["TakerId"].ToString());
                        lTakers.Add(taker);
                    }
                    return Json(lTakers, JsonRequestBehavior.AllowGet);
                }
                return Json(new Feedback("erro", "Não foram encontrados registros!"), JsonRequestBehavior.AllowGet);
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