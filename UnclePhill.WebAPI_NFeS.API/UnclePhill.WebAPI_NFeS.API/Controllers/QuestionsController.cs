using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Domain.Domain;
using UnclePhill.WebAPI_NFeS.Models.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionsController : MasterController, Default.IController<Questions>
    {

        private QuestionsDomain questionsDomain = new QuestionsDomain();

        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long QuestionId = 0)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(questionsDomain.Get(QuestionId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody] Questions obj)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody] Questions obj)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long QuestionId)
        {
            throw new NotImplementedException();
        }
    }
}