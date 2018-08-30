using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.API.Controllers;
using UnclePhill.WebAPI_NFeS.API.Models;
using UnclePhill.WebAPI_NFeS.WS.Domain;
using UnclePhill.WebAPI_NFeS.WS.Models;

namespace UnclePhill.WebAPI_NFeS.WS.Controllers
{
    public class CompanyController : MasterController
    {
        CompanyDomain companyDomain = new CompanyDomain();

        [HttpGet]
        public JsonResult Select(long? CompanyId = 0)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));

                return Response(companyDomain.Select(CompanyId));
            }
            catch (Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPost]
        public JsonResult Insert(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));
                            
                if (companyDomain.Insert(companys))
                {
                    return Response(new Feedbacks("ok", "Tomador criado com sucesso!"));
                }

                return Response(new Feedbacks("erro", "Houve um problema o tomador um usuário. Tente novamente!"));
            }
            catch(Exception ex)
            {
                return Response(new Feedbacks("erro", ex.Message));
            }            
        }

        [HttpPut]
        public JsonResult Update(Companys companys)
        {
            try
            {
                if (!base.CheckSession()) return Response(new Feedbacks("erro", "Sessão inválida!"));
                                
                if (companyDomain.Update(companys))
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