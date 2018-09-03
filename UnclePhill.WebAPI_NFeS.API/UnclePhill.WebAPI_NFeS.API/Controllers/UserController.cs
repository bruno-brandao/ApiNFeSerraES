using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class UserController : MasterController
    {
        private UsersDomain usersDomain = new UsersDomain();

        [HttpPost]
        public JsonResult Login(string Email, string Password)
        {
            try
            {
                UpdateSession();                

                return Response(usersDomain.Login(Email, Password));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        public JsonResult Get(long UserId)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida ou inexistente!")); }

                return Response(usersDomain.Get(UserId));
            }catch(Exception ex)
            {
                return Response(new Feedbacks("erro",ex.Message));
            }
        }

        [HttpPost]
        public JsonResult Post(Users users)
        {
            try
            {
                UpdateSession();                              
                                
                if (usersDomain.Post(users))
                {
                    return Response(new Feedbacks("ok", "Usuário criado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao criar um usuário. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpPut]
        public JsonResult Put(Users users)
        {
            try
            {
                if (!base.CheckSession()){return Response(new Feedbacks("erro", "Sessão inválida ou inexistente!"));}

                if (usersDomain.Put(users))
                {
                    return Response(new Feedbacks("ok", "Usuário atualizado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao cadastrar um usuário. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }               
    }
}
