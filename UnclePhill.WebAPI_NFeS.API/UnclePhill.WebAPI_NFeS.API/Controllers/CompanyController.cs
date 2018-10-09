using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using UnclePhill.WebAPI_NFeS.Models.Models;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    public class CompanyController : MasterController,Default.IController<Companys>
    {
        CompanyDomain companyDomain = new CompanyDomain();

        /// <summary>
        /// Retorna uma lista de empresas
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="CompanyId">Opcional: Código da empresa</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns> 

        [System.Web.Http.ActionName("Get")]
        public IHttpActionResult Get(long CompanyId = 0)
        {
            try
            {
                //if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(companyDomain.Get<List<Companys>>(CompanyDomain.Type.Company, CompanyId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [System.Web.Http.ActionName("GetByUser")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetByUser(long UserId = 0)
        {
            try
            {
                //if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(companyDomain.Get<List<Companys>>(CompanyDomain.Type.User, UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria uma empresa
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="Company">Objeto empresa</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Post")]
        public IHttpActionResult Post([FromBody]Companys Company)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");                
                return Ok(companyDomain.Post(Company, SessionDomain.GetUserSession(base.Sessao())));                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Atualiza uma empresa
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="Company">Objeto empresa</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Put")]
        public IHttpActionResult Put([FromBody]Companys Company)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");
                return Ok(companyDomain.Put(Company, SessionDomain.GetUserSession(base.Sessao())));                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary>
        /// Exclui uma empresa pelo Id
        /// </summary>
        /// <param name="SessionHash">Paramentro passado no Header da requisição</param>
        /// <param name="CompanyId">Id da empresa</param>
        /// <returns code = "200">Sucesso</returns>
        /// <returns code = "400">Erro</returns>
        [System.Web.Http.ActionName("Delete")]
        public IHttpActionResult Delete(long CompanyId)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");

                if (companyDomain.Delete(CompanyId))
                {
                    return Ok("Empresa excluido com sucesso!");
                }

                return BadRequest("Houve um erro ao excluir a empresa. Tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }        
    }
}