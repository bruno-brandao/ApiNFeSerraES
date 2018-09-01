using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class ShippingCompanyController : MasterController
    {
        ShippingCompanyDomain shippingCompanyDomain = new ShippingCompanyDomain();

        [HttpGet]
        public JsonResult Select(long? ShippingCompanyId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(shippingCompanyDomain.Select(ShippingCompanyId));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpPost]
        public JsonResult Insert(ShippingCompany shippingCompany)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }
                                
                if (shippingCompanyDomain.Insert(shippingCompany))
                {
                    return Response(new Feedbacks("ok", "Transportadora criada com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao criar a transportadora. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpPut]
        public JsonResult Update(ShippingCompany shippingCompany)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                if (shippingCompanyDomain.Update(shippingCompany))
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
        public JsonResult Delete(long ShippingCompanyId)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }
                                
                if (shippingCompanyDomain.Delete(ShippingCompanyId))
                {
                    return Response(new Feedbacks("ok", "Transportadora excluida com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao excluir a transportadora. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }        
    }
}