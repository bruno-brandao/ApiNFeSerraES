using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using System.Web.Http.Description;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class CFPSController : MasterController, Default.IController<CFPS>
    {     
        private CFPSDomain cFPSDomain = new CFPSDomain();

        /// <summary>
        /// Retorna uma lista de CFPS's
        /// </summary>
        /// <param name="CFPSId">Opcional: Código do CFPS</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long CFPSId = 0)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(cFPSDomain.Get<List<CFPS>>(CFPSId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody] CFPS CFPS)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] CFPS CFPS)
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