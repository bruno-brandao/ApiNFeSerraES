using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnclePhill.Common.Repository.Entity;
using UnclePhill.WebAPI_NFeS.DataAcess.Entity.Context;
using UnclePhill.WebAPI_NFeS.Domain;

namespace UnclePhill.WebAPI_NFeS.Repository.Entity
{
    public class RepositoryUser: RepositoryUnclePhill<User,long>
    {
        public RepositoryUser(NFeS_DBContext context) : base(context)
        {

        }
    }
}
