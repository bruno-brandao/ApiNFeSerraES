using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Repository;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class MasterController : ApiController
    {
        protected BD_NFeS Instace = new BD_NFeS();
    }
}