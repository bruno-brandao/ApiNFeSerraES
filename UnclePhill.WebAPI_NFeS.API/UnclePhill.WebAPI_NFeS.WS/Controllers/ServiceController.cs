using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class ServiceController : MasterController
    {
        private ServiceDomain serviceDomain = new ServiceDomain();

        [HttpGet]
        public JsonResult Select(long? ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(serviceDomain.Select(ServicesId));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpPost]
        public JsonResult Insert(Services services)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                if(serviceDomain.Insert(services))
                {
                    return Response(new Feedbacks("ok", "Serviço criado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao criar um serviço. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpPut]
        public JsonResult Update(Services services)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                if (serviceDomain.Update(services))
                {
                    return Response(new Feedbacks("ok", "Serviço atualizado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao atualizar o serviço. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpDelete]
        public JsonResult Delete(long ServicesId)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                if (serviceDomain.Delete(ServicesId))
                {
                    return Response(new Feedbacks("ok", "Serviço excluido com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao excluir o serviço. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }        
    }
}