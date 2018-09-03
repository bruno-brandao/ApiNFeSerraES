using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class CompanyController : MasterController
    {
        CompanyDomain companyDomain = new CompanyDomain();

        [HttpGet]
        public JsonResult Get(long? CompanyId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(companyDomain.Get(CompanyId));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPost]
        public JsonResult Post(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));
                            
                if (companyDomain.Post(companys,GetUserSession()))
                {
                    return Response(new Feedbacks("ok", "Empresa criada com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema ao cadastrar uma empresa. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPut]
        public JsonResult Put(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));
                                
                if (companyDomain.Put(companys,GetUserSession()))
                {
                    return Response(new Feedbacks("ok", "Empresa atualizada com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao atualizar a empresa. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpDelete]
        public JsonResult Delete(long CompanyId)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                if (companyDomain.Delete(CompanyId))
                {
                    return Response(new Feedbacks("ok", "Empresa excluido com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um erro ao excluir a empresa. Tente novamente!"));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }        
    }
}