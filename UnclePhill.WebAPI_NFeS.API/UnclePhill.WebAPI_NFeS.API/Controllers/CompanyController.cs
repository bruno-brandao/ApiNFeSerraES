using System;
using System.Web.Mvc;
using UnclePhill.WebAPI_NFeS.Models;
using UnclePhill.WebAPI_NFeS.Domain;
using System.Web.Http;
using UnclePhill.WebAPI_NFeS.Models.Models;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
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
        public IHttpActionResult Get(long? CompanyId = 0)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");

                return Ok(companyDomain.Get(CompanyId));
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
        public IHttpActionResult Post([FromBody]Companys Company)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");

                if (companyDomain.Post(Company, SessionDomain.GetUserSession(base.Sessao())))
                {
                    return Ok("Empresa criada com sucesso!");
                }

                return BadRequest("Houve um problema ao cadastrar uma empresa. Tente novamente!");
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
        public IHttpActionResult Put([FromBody]Companys Company)
        {
            try
            {
                if (!SessionDomain.CheckSession(base.Sessao())) return BadRequest("Sessão inválida!");

                if (companyDomain.Put(Company, SessionDomain.GetUserSession(base.Sessao())))
                {
                    return Ok("Empresa atualizada com sucesso!");
                }

                return BadRequest("Houve um erro ao atualizar a empresa. Tente novamente!");
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