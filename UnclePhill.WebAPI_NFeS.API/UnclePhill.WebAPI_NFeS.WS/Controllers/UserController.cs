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
                SQL.AppendLine(" And Email Like '" + NoInjection(Email) + "'");
                SQL.AppendLine(" And Password Like '" + NoInjection(Password) + "'");

                DataTable data = Conn.GetDataTable(SQL.ToString(), "Users");                
                if (data != null && data.Rows.Count > 0) {
                    DataRow row = data.AsEnumerable().First();
                    Users user = new Users();
                    user.UserId = row.Field<long>("UserId");
                    user.Name = row.Field<string>("Name");
                    user.LastName = row.Field<string>("LastName");
                    user.CPF = row.Field<string>("CPF");
                    user.Email = row.Field<string>("Email");
                    user.Password = row.Field<string>("Password");
                    user.Active = row.Field<bool>("Active");
                    user.DateInsert = row.Field<DateTime>("DateInsert").ToString("dd-MM-yyyy");
                    user.DateUpdate = row.Field<DateTime>("DateUpdate").ToString("dd-MM-yyyy");
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
                Feedback feedback = Validate(user);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
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
                SQL.AppendLine("    '" + NoInjection(user.Name) + "',");
                SQL.AppendLine("    '" + NoInjection(user.LastName) + "',");
                SQL.AppendLine("    '" + NoInjection(user.CPF) + "',");
                SQL.AppendLine("    '" + NoInjection(user.Email) + "',");
                SQL.AppendLine("    '" + NoInjection(user.Password) + "',");
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

                Feedback feedback = Validate(user);
                if (feedback.Status.Equals("erro"))
                {
                    return Response(feedback);
                }

                SQL.AppendLine(" Update Users Set ");
                SQL.AppendLine("    Name = '" + NoInjection(user.Name) + "',");
                SQL.AppendLine("    LastName = '" + NoInjection(user.LastName) + "',");
                SQL.AppendLine("    CPF = '" + NoInjection(user.CPF) + "',");
                SQL.AppendLine("    Email = '" + NoInjection(user.Email) + "',");
                SQL.AppendLine("    Password = '" + NoInjection(user.Password) + "',");
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

        private Feedback Validate(Users users)
        {            

            if (string.IsNullOrEmpty(users.Name))
            {
                return new Feedback("erro", "Informe o nome do usuário!");
            }

            if (string.IsNullOrEmpty(users.LastName))
            {
                return new Feedback("erro", "Informe o Sobrenome do usuário!");
            }

            if (string.IsNullOrEmpty(users.CPF))
            {
                return new Feedback("erro", "Informe o CPF do usuário!");
            }

            if (string.IsNullOrEmpty(users.Email))
            {
                return new Feedback("erro", "Informe o Email do usuário!");
            }

            if (string.IsNullOrEmpty(users.Password))
            {
                return new Feedback("erro", "Informe a senha do usuário!");
            }

            return new Feedback("ok", "Sucesso");
        }
    }
}
