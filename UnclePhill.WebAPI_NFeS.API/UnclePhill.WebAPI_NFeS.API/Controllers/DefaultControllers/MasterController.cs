using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Serialization;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Utils.Utils;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class MasterController : ApiController
    {        
        protected string Sessao()
        {
            try
            {
                return Request.Headers.GetValues("SessionHash").FirstOrDefault();
            }
            catch
            {
                throw new Exception("É necessário enviar a chave hash da sessão, gerada ao fazer login, no cabeçalho desta requisição.");
            }            
        }
       
    }
}