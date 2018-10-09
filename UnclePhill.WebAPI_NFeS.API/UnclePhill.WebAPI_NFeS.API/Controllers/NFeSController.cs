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
        [System.Web.Http.ActionName("IssueNFeS")]
        public IHttpActionResult IssueNFeS([FromBody] NFeSRequest NFeSR)
        {
            try
            {
                //if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.IssueNFeS(NFeSR));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody] NFeSRequest NFeSR)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] NFeSRequest obj)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long Id)
        {
            throw new NotImplementedException();
        }
    }
}