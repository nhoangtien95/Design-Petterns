using System.Web;
using System.Web.Mvc;

namespace Repository_and_Unit_of_Work_Patterns
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
