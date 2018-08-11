using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnclePhill.WebAPI_NFeS.Repository;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class UserController : ApiController
    {

        private BD_NFeS Instace = new BD_NFeS();

        public List<Users> Get()
        {
            return Instace.Users.ToList();
        }
    }
}
