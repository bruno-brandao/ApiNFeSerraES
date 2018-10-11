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
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Web.Http.Cors;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class TakerController : MasterController, Default.IController<Takers>
    {
        private TakerDomain takerDomain = new TakerDomain();

        /// <summary>
        /// Retorna uma lista de tomadores de serviço
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="TakerId">Opcional: Código do tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long TakerId = 0)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
                return Ok(takerDomain.Get<List<Takers>>(TakerId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Cria um tomador
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="Taker">Objeto tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody]Takers Taker)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }                                
                return Ok(takerDomain.Post(Taker));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Atualiza um tomador
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="Taker">Objeto tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody]Takers Taker)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
                return Ok(takerDomain.Put(Taker));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um tomador pelo Id
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="TakerId">Id do tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long TakerId)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }
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