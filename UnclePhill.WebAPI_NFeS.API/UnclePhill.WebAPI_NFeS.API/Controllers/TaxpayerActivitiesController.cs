using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class TaxpayerActivitiesController : MasterController
    {
        TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();

        /// <summary>
        /// Retorna uma lista de CFPS's
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="CFPSId">Opcional: Código do CFPS</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>        
        public IHttpActionResult Get(long CompanyId)
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
                if (!base.CheckSession()) return BadRequest("Sessão inválida!");

                return Ok(taxpayerActivitiesDomain.Get(CompanyId));                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);              
            }
        }
    }
}