using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Domain;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class TaxpayerActivitiesController : MasterController
    {
        TaxpayerActivitiesDomain taxpayerActivitiesDomain = new TaxpayerActivitiesDomain();

        [HttpPost]
        public JsonResult Select(string CPF = "55555555555",
            string Password = "cRDtpNCeBiql5KOQsKVyrA0sAiA=",
            string IM = "4546565",
            int CodeCity = 3,
            long CompanyId = 0)
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

                return Response(taxpayerActivitiesDomain.Select(CPF, Password, IM, CodeCity, CompanyId));                
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));              
            }
        }
    }
}