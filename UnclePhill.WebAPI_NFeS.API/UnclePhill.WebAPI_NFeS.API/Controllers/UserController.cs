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

        public List<Users> Post()
        {
            return Instace.Users.ToList();
        }

        public Users Post(int? Id)
        {
            return Instace.Users.Where(Func => Func.UserId == Id).First();
        }

        public bool Put(Users users)
        {
            Instace.Users.Add(users);
            Instace.SaveChanges();
            return true;
        }
    }
}
