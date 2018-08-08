using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnclePhill.Common.Repository.Interface;
using UnclePhill.WebAPI_NFeS.DataAcess.Entity.Context;
using UnclePhill.WebAPI_NFeS.Domain;
using UnclePhill.WebAPI_NFeS.Repository.Entity;

namespace UnclePhill.WebAPI_NFeS.API.Controllers
{
    public class UserController : ApiController
    {
        private IRepositoryUnclePhill<User, long> _repositoryUser 
            = new RepositoryUser(new NFeS_DBContext());

        public IEnumerable<User> Get()
        {
            return _repositoryUser.Select();
        }

        public User Get(long? id)
        {
            return _repositoryUser.SelectByKey(id.Value);
        }
    }
}
