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
    public class ServiceController : MasterController
    {
        public JsonResult Select(long? ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Insert(Services services)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Update(Services services)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch (Exception ex)
            {
                return Response(ex.Message);
            }
        }

        public JsonResult Delete(long ServicesId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(null);
            }
            catch(Exception ex)
            {
                return Response(ex.Message);
            }
        }

        private Feedbacks Validate()
        {
            return new Feedbacks("ok","Sucesso");
        }
    }
}