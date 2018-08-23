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
            try
            {
                if (!base.CheckSession()) return Response(new Feedback("erro", "Sessão inválida!"));
                
                return Response(null);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        public JsonResult Insert(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedback("erro", "Sessão inválida!"));
                

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        public JsonResult Update(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedback("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        public JsonResult Delete(long CompanyId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedback("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }            
        }

        private Feedback Validate(Companys companys)
        {
            return new Feedback("","");
        }
    }
}