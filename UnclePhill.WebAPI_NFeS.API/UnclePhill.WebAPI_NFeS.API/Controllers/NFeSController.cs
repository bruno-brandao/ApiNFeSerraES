using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class NFeSController : MasterController
    {
        private NFeSDomain nFeSDomain = new NFeSDomain();

        /// <summary>
        /// Metodo de emissão de nota fiscal em ambiente de desenvolvimento
        /// </summary>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Issue")]
        public IHttpActionResult Issue([FromBody] NFeSRequest NFeSR)
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

        /// <summary>
        /// Método para buscar a nota fiscal (XML) já autorizada
        /// </summary>
        /// <param name="NFeSRequestXml"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetXml")]
        public IHttpActionResult GetXml(long CompanyId, string NFNumber)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.GetNFeS(CompanyId, NFNumber,NFeSDomain.TypeArchive.Xml));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a nota fiscal (PDF) já autorizada
        /// </summary>
        /// <param name="NFeSRequestXml"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetPdf")]
        public IHttpActionResult GetPdf(long CompanyId, string NFNumber)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.GetNFeS(CompanyId, NFNumber,NFeSDomain.TypeArchive.PDF));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a nota fiscal (URL) já autorizada
        /// </summary>
        /// <param name="NFeSRequestXml"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetUrl")]
        public IHttpActionResult GetUrl(long CompanyId, string NFNumber)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.GetNFeS(CompanyId, NFNumber, NFeSDomain.TypeArchive.URL));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a nota fiscal (URL) já autorizada
        /// </summary>
        /// <param name="NFeSRequestXml"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetUrlAuth")]
        public IHttpActionResult GetUrlAuth(long CompanyId, string NFNumber)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(nFeSDomain.GetNFeS(CompanyId, NFNumber, NFeSDomain.TypeArchive.URLAuth));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método para solicitar o cancelamento de uma nota fiscal
        /// </summary>
        /// <param name="NFeSRequestCancel"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 
        [System.Web.Http.HttpDelete]
        [System.Web.Http.ActionName("Cancel")]
        public IHttpActionResult Cancel(long CompanyId, string NFNumber)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                if (nFeSDomain.Cancel(CompanyId,NFNumber))
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
    }
}