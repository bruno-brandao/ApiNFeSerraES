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

        /// <summary>
        /// Faz a autênticação do usuário
        /// </summary>        
        /// <param name="Email">Email do usuário</param>
        /// <param name="Password">Senha do usuário</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
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

        /// <summary>
        /// Retorna o usuário por Id
        /// </summary>
        /// <param name="UserId">Id do usuário</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
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

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="users">Objeto usuário</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        public IHttpActionResult Post([FromBody]Users users)
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

        /// <summary>
        /// Atualiza o usuário
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="users">Objeto usuário</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        public IHttpActionResult Put([FromBody]Users users)
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
