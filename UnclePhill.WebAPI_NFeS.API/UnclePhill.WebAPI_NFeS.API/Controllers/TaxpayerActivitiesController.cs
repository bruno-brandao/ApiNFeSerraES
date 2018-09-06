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