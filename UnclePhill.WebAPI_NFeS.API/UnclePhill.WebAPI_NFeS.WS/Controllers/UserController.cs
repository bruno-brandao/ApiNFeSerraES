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
                    return Response(new Feedback("erro", "Email ou senha não informado!"));
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
                return Response(new Feedback("erro", "Email ou senha inválidos!"));
            } catch (Exception ex) {
                return Response(new Feedback("erro", ex.Message));
            }
        } 
        
        public JsonResult Insert(Users user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name))
                {
                    return Response(new Feedback("erro", "Informe o nome do usuário!"));
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    return Response(new Feedback("erro", "Informe o Sobrenome do usuário!"));
                }

                if (string.IsNullOrEmpty(user.CPF))
                {
                    return Response(new Feedback("erro", "Informe o CPF do usuário!"));
                }

                if (string.IsNullOrEmpty(user.Email))
                {
                    return Response(new Feedback("erro", "Informe o Email do usuário!"));
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    return Response(new Feedback("erro", "Informe a senha do usuário!"));
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
                    return Response(new Feedback("ok", "Usuário criado com sucesso!"));
                }

                return Response(new Feedback("erro", "Houve um problema ao cadastrar um usuário. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedback("erro", ex.Message));
            }
        }

        public JsonResult Update(Users user)
        {
            try
            {
                if (user.UserId <= 0)
                {
                    return Response(new Feedback("erro","Informe o código do usuário!"));
                }

                if (string.IsNullOrEmpty(user.Name))
                {
                    return Response(new Feedback("erro", "Informe o nome do usuário!"));
                }

                if (string.IsNullOrEmpty(user.LastName))
                {
                    return Response(new Feedback("erro", "Informe o Sobrenome do usuário!"));
                }

                if (string.IsNullOrEmpty(user.CPF))
                {
                    return Response(new Feedback("erro", "Informe o CPF do usuário!"));
                }

                if (string.IsNullOrEmpty(user.Email))
                {
                    return Response(new Feedback("erro", "Informe o Email do usuário!"));
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    return Response(new Feedback("erro", "Informe a senha do usuário!"));
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
                    return Response(new Feedback("ok","Usuário atualizado com sucesso!"));
                }

                return Response(new Feedback("erro", "Houve um problema ao cadastrar um usuário. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedback("erro",ex.Message));
            }
        }
    }
}
