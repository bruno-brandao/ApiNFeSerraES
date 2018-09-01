using System.Web;
using System.Web.Mvc;

namespace UnclePhill.WebAPI_NFeS.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
