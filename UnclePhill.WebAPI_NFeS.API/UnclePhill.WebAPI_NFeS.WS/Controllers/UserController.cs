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
        
        public JsonResult Insert(Users user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name))
                {
                    return Json(new Feedback("erro", "Informe o nome do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    return Json(new Feedback("erro", "Informe o Sobrenome do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.CPF))
                {
                    return Json(new Feedback("erro", "Informe o CPF do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.Email))
                {
                    return Json(new Feedback("erro", "Informe o Email do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    return Json(new Feedback("erro", "Informe a senha do usuário!"), JsonRequestBehavior.AllowGet);
                }

                SQL.AppendLine(" Insert Into Users ");
                SQL.AppendLine("   (Name, ");
                SQL.AppendLine("    LastName, ");
                SQL.AppendLine("    CPF, ");
                SQL.AppendLine("    Email, ");
                SQL.AppendLine("    Password, ");
                SQL.AppendLine("    Active, ");
                SQL.AppendLine("    DateInsert, ");
                SQL.AppendLine("    DateUpdate) ");
                SQL.AppendLine(" Values( ");
                SQL.AppendLine("    '" + R(user.Name) + "',");
                SQL.AppendLine("    '" + R(user.LastName) + "',");
                SQL.AppendLine("    '" + R(user.CPF) + "',");
                SQL.AppendLine("    '" + R(user.Email) + "',");
                SQL.AppendLine("    '" + R(user.Password) + "',");
                SQL.AppendLine("    1,");
                SQL.AppendLine("    GetDate(),");
                SQL.AppendLine("    GetDate() ");
                SQL.AppendLine(" ) ");

                if (Conn.Execute(SQL.ToString()))
                {
                    return Json(new Feedback("ok", "Usuário criado com sucesso!"), JsonRequestBehavior.AllowGet);
                }

                return Json(new Feedback("erro", "Houve um problema ao cadastrar um usuário. Tente novamente!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro", ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(Users user)
        {
            try
            {
                if (user.UserId < 0)
                {
                    return Json(new Feedback("erro","Informe o código do usuário!"),JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.Name))
                {
                    return Json(new Feedback("erro", "Informe o nome do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    return Json(new Feedback("erro", "Informe o Sobrenome do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.CPF))
                {
                    return Json(new Feedback("erro", "Informe o CPF do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.Email))
                {
                    return Json(new Feedback("erro", "Informe o Email do usuário!"), JsonRequestBehavior.AllowGet);
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    return Json(new Feedback("erro", "Informe a senha do usuário!"), JsonRequestBehavior.AllowGet);
                }

                SQL.AppendLine(" Update Users Set ");
                SQL.AppendLine("    Name = '" + R(user.Name) + "',");
                SQL.AppendLine("    LastName = '" + R(user.LastName) + "',");
                SQL.AppendLine("    CPF = '" + R(user.CPF) + "',");
                SQL.AppendLine("    Email = '" + R(user.Email) + "',");
                SQL.AppendLine("    Password = '" + R(user.Password) + "',");
                SQL.AppendLine("    Active = 1,");
                SQL.AppendLine("    DateUpdate = GetDate() ");
                SQL.AppendLine(" Where UserId = " + user.UserId);
               
                if (Conn.Execute(SQL.ToString()))
                {
                    return Json(new Feedback("ok","Usuário atualizado com sucesso!"));
                }

                return Json(new Feedback("erro", "Houve um problema ao cadastrar um usuário. Tente novamente!"), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new Feedback("erro",ex.Message),JsonRequestBehavior.AllowGet);
            }
        }
    }
}
