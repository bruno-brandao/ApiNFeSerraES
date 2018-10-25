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
using UnclePhill.WebAPI_NFeS.Models.Models;
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
                throw new InternalProgramException("É necessário enviar a chave hash da sessão, gerada ao fazer login, no cabeçalho desta requisição.");
            }            
        }

        protected IHttpActionResult Exceptions(Exception ex)
        {            
            if (ex is InternalProgramException) //Exeções internas da aplicação
            {
                return BadRequest(ex.Message);
            }else if (ex is InvalidOperationException)
            {
                return Unauthorized() ;
            }
            else //Outras exeções
            {
                return InternalServerError(ex); 
            }
        }
    }
}