using System;
using System.Web.Http;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class NFeSController : MasterController
    {
        private NFeSDomain nFeSDomain = new NFeSDomain();
        
        /// <summary>
        /// Metodo de emissão de nota fiscal em ambiente de desenvolvimento
        /// </summary>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [HttpGet]
        public IHttpActionResult EmitirNFeS()
        {
            try
            {
                return Ok(nFeSDomain.EmitirNFeS(null));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

    }
}