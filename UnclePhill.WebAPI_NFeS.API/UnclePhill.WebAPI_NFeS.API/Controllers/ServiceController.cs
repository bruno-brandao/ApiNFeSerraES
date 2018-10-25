using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using System.Web.Routing;
using UnclePhill.WebAPI_NFeS.API.Controllers.Default;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class ServiceController : MasterController, Default.IController<Services>
    {        
        private ServiceDomain serviceDomain = new ServiceDomain();

        /// <summary>
        /// Retorna uma lista as serviços
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="ServicesId">Opcional: Código do serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long ServicesId = 0)
        {
            try
            {
                SessionDomain.CheckSession(base.Sessao());
                return Ok(serviceDomain.Get<List<Services>>(ServicesId));
            }
            catch(Exception ex)
            {
                return Exceptions(ex);
            }
        }

        /// <summary>
        /// Cria uma serviço
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="services">Objeto serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody] Services Service)
        {
            try
            {
                SessionDomain.CheckSession(base.Sessao());
                return Ok(serviceDomain.Post(Service));
            }
            catch (Exception ex)
            {
                return Exceptions(ex);
            }
        }

        /// <summary>
        /// Atualiza um serviço
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="services">Objeto serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] Services Service)
        {
            try
            {
                SessionDomain.CheckSession(base.Sessao());
                return Ok(serviceDomain.Put(Service));
            }
            catch (Exception ex)
            {
                return Exceptions(ex);
            }
        }

        /// <summary>
        /// Exclui um serviço pelo Id
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="ServicesId">Id do serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long ServicesId)
        {
            try
            {
                SessionDomain.CheckSession(base.Sessao());
                if (serviceDomain.Delete(ServicesId))
                {
                    return Ok("Serviço excluido com sucesso!");
                }

                return BadRequest("Houve um erro ao excluir o serviço. Tente novamente!");
            }
            catch (Exception ex)
            {
                return Exceptions(ex);
            }
        }
    }
}