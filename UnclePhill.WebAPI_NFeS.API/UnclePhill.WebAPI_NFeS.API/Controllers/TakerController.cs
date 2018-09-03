using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.Controllers
{
    public class TakerController : MasterController
    {

        private TakerDomain takerDomain = new TakerDomain();

        [HttpGet]
        public JsonResult Get(long? TakerId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(takerDomain.Get(TakerId));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPost]
        public JsonResult Post(Takers takers)
        {
            try
            {
                if (!base.CheckSession()){ return Response(new Feedbacks("erro", "Sessão inválida!"));}

                if (takerDomain.Post(takers))
                { 
                    return Response(new Feedbacks("ok", "Tomador criado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao criar um tomador. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPut]
        public JsonResult Put(Takers takers)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                if (takerDomain.Put(takers))
                {
                    return Response(new Feedbacks("ok","Tomador atualizado com sucesso!"));
                }

                return Response(new Feedbacks("erro","Houve um erro ao atualizar o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }

        [HttpDelete]
        public JsonResult Delete(long TakerId)
        {
            try
            {
                if (!base.CheckSession()) { return Response(new Feedbacks("erro", "Sessão inválida!")); }

                
                if (takerDomain.Delete(TakerId))
                {
                    return Response(new Feedbacks("ok","Tomador excluido com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao excluir o tomador. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }
        }        
    }
}