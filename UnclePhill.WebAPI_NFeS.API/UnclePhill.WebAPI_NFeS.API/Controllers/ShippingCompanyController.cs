using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class ShippingCompanyController : MasterController
    {
        ShippingCompanyDomain shippingCompanyDomain = new ShippingCompanyDomain();

        public IHttpActionResult Get(long? ShippingCompanyId)
        {
            try
            {
                if (!base.CheckSession()) return BadRequest("Sessão inválida!");

                return Ok(shippingCompanyDomain.Get(ShippingCompanyId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post(ShippingCompany shippingCompany)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }
                                
                if (shippingCompanyDomain.Post(shippingCompany))
                {
                    return Ok("Transportadora criada com sucesso!");
                }

                return BadRequest("Houve um problema ao criar a transportadora. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(ShippingCompany shippingCompany)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

                if (shippingCompanyDomain.Put(shippingCompany))
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

        public IHttpActionResult Delete(long ShippingCompanyId)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }
                                
                if (shippingCompanyDomain.Delete(ShippingCompanyId))
                {
                    return Ok("Transportadora excluida com sucesso!");
                }

                return BadRequest("Houve um erro ao excluir a transportadora. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}