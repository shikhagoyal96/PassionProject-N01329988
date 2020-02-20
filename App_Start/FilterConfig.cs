using System.Web;
using System.Web.Mvc;

namespace PassionProject_N01329988
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
