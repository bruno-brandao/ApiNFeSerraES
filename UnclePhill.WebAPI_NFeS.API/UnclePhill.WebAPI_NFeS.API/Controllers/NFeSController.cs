using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class NFeSController : MasterController, Default.IController<NFeSRequest>
    {
        private NFeSDomain nFeSDomain = new NFeSDomain();         
        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long Id = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo de emissão de nota fiscal em ambiente de desenvolvimento
        /// </summary>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.ActionName("Issue")]
        public IHttpActionResult Post([FromBody] NFeSRequest NFeSR)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.Issue(NFeSR));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] NFeSRequest obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para solicitar o cancelamento de uma NFeS
        /// </summary>
        /// <param name="NFeSRequestCancel"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpDelete]
        [System.Web.Http.ActionName("Cancel")]
        public IHttpActionResult Cancel([FromBody]NFeSRequestCancel NFeSRequestCancel)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                if (nFeSDomain.Cancel(NFeSRequestCancel))
                {
                    return Ok();
                }
                return BadRequest("Não foi possivel cancelar a nota fiscal.");
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