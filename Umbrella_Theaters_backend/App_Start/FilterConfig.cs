using System.Web;
using System.Web.Mvc;

namespace Umbrella_Theaters_backend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
