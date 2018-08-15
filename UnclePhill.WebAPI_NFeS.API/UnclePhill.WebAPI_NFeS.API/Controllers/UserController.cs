using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class UserController : MasterController
    {
        //Login:
        public JsonResult Login(string Email, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    return Json(new Feedback("erro", "Email ou senha não informado!"));
                }

                SQL.AppendLine(" Select * From Users ");
                SQL.AppendLine(" Where Email Like '" + Email + "'");
                SQL.AppendLine(" And Password Like '" + Password + "'");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Users");
                if (data != null && data.Rows.Count > 0) {
                    return Json(data.AsEnumerable().ToList(), JsonRequestBehavior.AllowGet);
                }
                return Json(new Feedback("erro", "Email ou senha inválidos!"));
            } catch (Exception ex) {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        } 
        
        public JsonResult Get()
        {
            return Json(new Feedback("erro", "Vai tomar no cú!"));
        }
    }
}
