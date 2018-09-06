using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class UserController : MasterController
    {
        private UsersDomain usersDomain = new UsersDomain();

        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(string Email, string Password)
        {
            try
            {
                UpdateSession();                

                return Ok(usersDomain.Login(Email, Password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(long UserId)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida ou inexistente!"); }

                return Ok(usersDomain.Get(UserId));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        public IHttpActionResult Post(Users users)
        {
            try
            {
                UpdateSession();                              
                                
                if (usersDomain.Post(users))
                {
                    return Ok("Usuário criado com sucesso!");
                }

                return BadRequest("Houve um problema ao criar um usuário. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        public IHttpActionResult Put(Users users)
        {
            try
            {
                if (!base.CheckSession()){return BadRequest("Sessão inválida ou inexistente!");}

                if (usersDomain.Put(users))
                {
                    return Ok("Usuário atualizado com sucesso!");
                }

                return BadRequest("Houve um problema ao cadastrar um usuário. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }               
    }
}
