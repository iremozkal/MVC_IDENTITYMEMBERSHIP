using System.Web;
using System.Web.Mvc;

namespace IDENTITY_MEMBERSHIP
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}