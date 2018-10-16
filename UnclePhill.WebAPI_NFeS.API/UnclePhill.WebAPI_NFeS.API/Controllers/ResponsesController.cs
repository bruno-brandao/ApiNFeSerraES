using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Domain.Domain;
using UnclePhill.WebAPI_NFeS.Models.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResponsesController : MasterController, Default.IController<Responses>
    {
        private ResponsesDomain responsesDomain = new ResponsesDomain();

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long Id = 0)
        {
            throw new NotImplementedException();
        }

        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody] Responses obj)
        {
            try
            {
                if (responsesDomain.Post(obj))
                {
                    return Ok();
                }
                return BadRequest("Não foi possivel registrar a resposta!");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] Responses obj)
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