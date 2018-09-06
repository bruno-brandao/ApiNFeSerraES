using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class ServiceController : MasterController
    {
        private ServiceDomain serviceDomain = new ServiceDomain();

        public IHttpActionResult Get(long? ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return BadRequest("Sessão inválida!");

                return Ok(serviceDomain.Get(ServicesId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post(Services services)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

                if(serviceDomain.Post(services))
                {
                    return Ok("Serviço criado com sucesso!");
                }

                return BadRequest("Houve um problema ao criar um serviço. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(Services services)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

                if (serviceDomain.Put(services))
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

        public IHttpActionResult Delete(long ServicesId)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

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