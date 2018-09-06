using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class CFPSController : MasterController
    {     
        private CFPSDomain cFPSDomain = new CFPSDomain();
        
        /// <summary>
        /// Retorna uma lista de CFPS's
        /// </summary>
        /// <param name="CFPSId">Opcional: Código do CFPS</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        
        public IHttpActionResult Get(long? CFPSId = 0)
        {
            try
            {
                if (!base.CheckSession()) return BadRequest("Sessão inválida!");

                return Ok(cFPSDomain.Get(CFPSId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}   