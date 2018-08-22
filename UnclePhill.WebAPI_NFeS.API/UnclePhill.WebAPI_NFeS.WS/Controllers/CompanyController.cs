using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class CompanyController : MasterController
    {
        public JsonResult Select()
        {
            return Response(null);
        }

        public JsonResult Insert(Companys companys)
        {
            return Response(null);
        }

        public JsonResult Update(Companys companys)
        {
            return Response(null);
        }

        public JsonResult Delete(long CompanyId)
        {
            return Response(null);
        }

        private Feedback Validade(Companys companys)
        {
            return new Feedback("","");
        }
    }
}