using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Models;

namespace UnclePhill.WebAPI_NFeS.API
{
    /// <summary>
    /// Descrição resumida de WebAPI_NFeS
    /// </summary>
    [WebService(Namespace = "http://unclephillwebapinfes.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebAPI_NFeS : System.Web.Services.WebService
    {

        [WebMethod]
        public Users Login(string Email, string Password)
        {
            return new UsersDomain().Login(Email, Password);
        }

        [WebMethod]
        public Users Get(long UserId)
        {
            return new UsersDomain().Get(UserId);
        }

        [WebMethod]
        public bool Post(Users users)
        {
            if (new UsersDomain().Post(users))
            {
                return true;
            }

            return false;            
        }
    }
}
