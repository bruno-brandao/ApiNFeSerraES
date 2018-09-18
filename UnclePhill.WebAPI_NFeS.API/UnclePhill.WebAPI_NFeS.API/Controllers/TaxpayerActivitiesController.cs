using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using System.Web.Http.Description;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class TaxpayerActivitiesController : MasterController,Default.IController<TaxpayerActivities>
    {
        TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();      

        /// <summary>
        /// Retorna uma lista de CFPS's
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="CFPSId">Opcional: Código do CFPS</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>      
        public IHttpActionResult Get(long? CompanyId)
        {
            try
            {
                /*****
                  Homologação Serra:
                  cpfUsuario:55555555555
                  hashSenha: cRDtpNCeBiql5KOQsKVyrA0sAiA=
                  inscricaoMunicipal = 4546565
                  codigoMunicipio = 3
                *****/

                if (!SessionDomain.CheckSession(Sessao())) { return BadRequest("Sessão inválida!"); }

                return Ok(taxpayerActivitiesDomain.Get(CompanyId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Delete(long Id)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Post([FromBody] TaxpayerActivities obj)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Put([FromBody] TaxpayerActivities obj)
        {
            throw new NotImplementedException();
        }
    }
}