using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
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
                SQL.AppendLine(" Where Active = 1 ");
                SQL.AppendLine(" And Email Like '" + Email + "'");
                SQL.AppendLine(" And Password Like '" + Password + "'");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Users");
                if (data != null && data.Rows.Count > 0) {
                    Users user = new Users();
                    user.UserId = data.AsEnumerable().First().Field<long>("UserId");
                    user.Name = data.AsEnumerable().First().Field<string>("Name");
                    user.LastName = data.AsEnumerable().First().Field<string>("LastName");
                    user.CPF = data.AsEnumerable().First().Field<string>("CPF");
                    user.Email = data.AsEnumerable().First().Field<string>("Email");
                    user.Password = data.AsEnumerable().First().Field<string>("Password");
                    user.Active = data.AsEnumerable().First().Field<bool>("Active");
                    user.DateInsert = data.AsEnumerable().First().Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                    user.DateUpdate = data.AsEnumerable().First().Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                return Json(new Feedback("erro", "Email ou senha inválidos!"), JsonRequestBehavior.AllowGet);
            } catch (Exception ex) {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }         
    }
}
