using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Domain.Domain;
using UnclePhill.WebAPI_NFeS.Models.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CertificatesController : MasterController, Default.IController<Certificates>
    {
        private CertificatesDomain certificateDomain = new CertificatesDomain();

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Get(long Id = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Função para upload do certificado digital
        /// </summary>
        /// <param name="Certificates"></param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [ActionName("UploadCerticate")]
        public IHttpActionResult Post([FromBody] Certificates Certificates)
        {
            try
            {
                //if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");

                if (certificateDomain.UploadCertificate(Certificates))
                {
                    return Ok();
                }
                return BadRequest("Não foi possivel cadastrar o certificado digital");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Put([FromBody] Certificates certificates)
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