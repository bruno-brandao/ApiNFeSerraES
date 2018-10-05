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
        public IHttpActionResult Get(long? ServicesId)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                return Ok(serviceDomain.Get<List<Services>>(ServicesId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria uma serviço
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="services">Objeto serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        public IHttpActionResult Post([FromBody] Services Service)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
                Service = serviceDomain.Post(Service);
                if (Service.ServicesId > 0)
                {
                    return Ok(Service);
                }

                return BadRequest("Houve um problema ao criar um serviço. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um serviço
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="services">Objeto serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        public IHttpActionResult Put([FromBody] Services Service)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                if (serviceDomain.Put(Service))
                {
                    return Ok("Serviço atualizado com sucesso!");
                }

                return BadRequest("Houve um erro ao atualizar o serviço. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um serviço pelo Id
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="ServicesId">Id do serviço</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        public IHttpActionResult Delete(long ServicesId)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                if (serviceDomain.Delete(ServicesId))
                {
                    return Ok("Serviço excluido com sucesso!");
                }

                return BadRequest("Houve um erro ao excluir o serviço. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}