﻿using System;
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
        public IHttpActionResult Get(long? Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo de emissão de nota fiscal em ambiente de desenvolvimento
        /// </summary>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Post([FromBody] NFeSRequest NFeSR)
        {
            try
            {
                //if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.EmitirNFeS(NFeSR));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Put([FromBody] NFeSRequest obj)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Delete(long Id)
        {
            throw new NotImplementedException();
        }
    }
}