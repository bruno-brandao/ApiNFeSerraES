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
    public class UserController : ApiController
    {

        private BD_NFeS Instace = new BD_NFeS();

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(Instace.Users.ToList());
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

        public IHttpActionResult Get(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return BadRequest();
                }

                Users user = Instace.Users.Where(Func => Func.UserId == Id).First();
                if (user == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.Found, user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

        public IHttpActionResult Post([FromBody] Users users)
        {
            try
            {
                Instace.Users.Add(users);
                Instace.SaveChanges();
                return Created(Request.RequestUri + "/" + users.UserId,users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        
    }
}
