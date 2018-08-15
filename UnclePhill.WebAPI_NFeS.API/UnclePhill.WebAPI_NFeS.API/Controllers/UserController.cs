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
    public class UserController : MasterController
    {
        //Login:
        [HttpGet]
        public IHttpActionResult login(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    NotFound();
                }
                Users users = Instace.Users.Where(Func => Func.Email == email && Func.Password == password).First();
                return Content(HttpStatusCode.Found,users);
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        //Selecionar:
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Instace.Users.ToList());
            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //Selecionar Por ID:
        public IHttpActionResult Get(int? Id)
        {
            try
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }

                Users users = Instace.Users.Where(Func => Func.UserId == Id).First();
                if (users == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.Found, users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //Inserir:
        public IHttpActionResult Post([FromBody] Users users)
        {
            try
            {
                Instace.Users.Add(users);
                Instace.SaveChanges();
                return Created(Request.RequestUri + "/" + users.UserId, users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        //Atualizar:
        public IHttpActionResult Put(int? Id, [FromBody] Users users)
        {
            try
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }
                users.UserId = Id.Value;
                if (Instace.Users.Where(Func => Func.UserId == users.UserId).ToList().Count > 0)
                {
                    Users userNow = Instace.Users.Where(Func => Func.UserId == users.UserId).ToList().First();
                    Instace.Entry(userNow).CurrentValues.SetValues(users);
                    Instace.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //Excluir:
        public IHttpActionResult Delete(int? Id)
        {
            try
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }

                if (Instace.Users.Where(Func => Func.UserId == Id).ToList().Count > 0)
                {
                    Users users = Instace.Users.Where(Func => Func.UserId == Id).ToList().First();
                    Instace.Entry(users).State = EntityState.Deleted;
                    Instace.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
                
    }
}
