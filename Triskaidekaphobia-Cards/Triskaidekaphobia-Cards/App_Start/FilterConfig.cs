using System.Web;
using System.Web.Mvc;

namespace Triskaidekaphobia_Cards
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
