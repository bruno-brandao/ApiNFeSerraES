using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http.Description;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [RoutePrefix("CFPS")]
    public class CFPSController : MasterController
    {     
        private CFPSDomain cFPSDomain = new CFPSDomain();
        /// <summary>
        /// Register a new user on application
        /// </summary>
        /// <param name="user">New user to register</param>
        /// <remarks>Adds new user to application and grant access</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [AllowAnonymous]
        [Route("Select")]
        [ResponseType(typeof(long))]
        [HttpGet]
        public JsonResult Select(long? CFPSId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(cFPSDomain.Select(CFPSId));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }        
    }
}   