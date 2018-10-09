using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UnclePhill.WebAPI_NFeS.API.Controllers.Default
{
    interface IController<T> where T: new()
    {
        IHttpActionResult Get(long Id = 0);

        IHttpActionResult Post([FromBody] T obj);

        IHttpActionResult Put([FromBody] T obj);

        IHttpActionResult Delete(long Id);
    }
}
