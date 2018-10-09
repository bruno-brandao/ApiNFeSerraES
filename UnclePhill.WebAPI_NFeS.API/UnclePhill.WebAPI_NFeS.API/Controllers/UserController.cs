using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using System.Web.Http.Description;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Web.Http.Cors;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class UserController : MasterController, Default.IController<Users>
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
        [System.Web.Http.ActionName("Login")]
        public IHttpActionResult Login(string Email, string Password)
        {
            try
            {
                SessionDomain.UpdateSession();
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
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long UserId = 0)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
                return Ok(usersDomain.Get(UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="Users">Objeto usuário</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody]Users Users)
        {
            try
            {
                SessionDomain.UpdateSession();                
                return Ok(usersDomain.Post(Users));
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
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody]Users users)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
                return Ok(usersDomain.Put(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
