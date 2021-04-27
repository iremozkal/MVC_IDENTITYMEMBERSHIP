using IDENTITY_MEMBERSHIP.Infastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using IDENTITY_MEMBERSHIP.Infastructure.Context;

namespace IDENTITY_MEMBERSHIP
{
	//? Application işlemlerini yapar.
	public class MvcApplication : System.Web.HttpApplication
	{
		//?  Applicationın ilk kez ayağa kalktığı an bu method.
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			//? Rol Oluşturma -----------------------------
			IdentityContext DB = new IdentityContext();
			RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(DB);
			RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(roleStore);

			if (!roleManager.RoleExists("Admin"))
			{
				ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem Yöneticisi");
				roleManager.Create(adminRole);
			}
			if (!roleManager.RoleExists("User"))
			{
				ApplicationRole userRole = new ApplicationRole("User", "Sistem Kullanıcısı");
				roleManager.Create(userRole);
			}
			//? ------------------------------------------
		}
	}
}