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

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
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
        public IHttpActionResult Get(long? TakerId = 0)
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
        public IHttpActionResult Post([FromBody]Takers Taker)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                if (takerDomain.Post(Taker))
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

        /// <summary>
        /// Atualiza um tomador
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="Taker">Objeto tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
        public IHttpActionResult Put([FromBody]Takers Taker)
        {
            try
            {
                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                if (takerDomain.Put(Taker))
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

        /// <summary>
        /// Exclui um tomador pelo Id
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="TakerId">Id do tomador</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
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