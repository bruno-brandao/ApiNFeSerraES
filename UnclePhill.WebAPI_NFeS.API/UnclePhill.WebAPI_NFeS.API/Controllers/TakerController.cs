using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.Controllers
{
    public class TakerController : MasterController
    {

        private TakerDomain takerDomain = new TakerDomain();
        
        public IHttpActionResult Get(long? TakerId = 0)
        {
            try
            {
                if (!base.CheckSession()) return BadRequest("Sessão inválida!");

                return Ok(takerDomain.Get(TakerId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        
        public IHttpActionResult Post(Takers takers)
        {
            try
            {
                if (!base.CheckSession()){ return BadRequest("Sessão inválida!");}

                if (takerDomain.Post(takers))
                { 
                    return Ok("Tomador criado com sucesso!");
                }

                return BadRequest("Houve um problema ao criar um tomador. Tente novamente!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        
        public IHttpActionResult Put(Takers takers)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

                if (takerDomain.Put(takers))
                {
                    return Ok("Tomador atualizado com sucesso!");
                }

                return BadRequest("Houve um erro ao atualizar o tomador. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        public IHttpActionResult Delete(long TakerId)
        {
            try
            {
                if (!base.CheckSession()) { return BadRequest("Sessão inválida!"); }

                
                if (takerDomain.Delete(TakerId))
                {
                    return Ok("Tomador excluido com sucesso!");
                }

                return BadRequest("Houve um erro ao excluir o tomador. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}