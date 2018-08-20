using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class MasterController : Controller
    {
        protected ConnectionManager Conn = new ConnectionManager();
        protected StringBuilder SQL = new StringBuilder();
        protected Session Session = new Session();

        public ActionResult Index()
        {
            return View();
        }
        
        protected string NoInjection(string Value)
        {
            return Value.Replace("'", "''");
        }

        protected JsonResult Response(object Param)
        {
            return Json(Param, JsonRequestBehavior.AllowGet);
        }

        protected bool CheckSession(string Session)
        {
            try
            {

                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}