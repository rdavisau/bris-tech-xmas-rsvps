using System.Web;
using System.Web.Mvc;

namespace BrisXmasTechDrinks2015Rsvps
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
