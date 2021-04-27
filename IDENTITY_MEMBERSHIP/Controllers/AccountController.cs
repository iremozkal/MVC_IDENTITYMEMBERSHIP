using IDENTITY_MEMBERSHIP.Infastructure.Identity;
using IDENTITY_MEMBERSHIP.Models.AccountVM;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using IDENTITY_MEMBERSHIP.Infastructure.Context;

namespace IDENTITY_MEMBERSHIP.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            IdentityContext DB = new IdentityContext();

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(DB);
            userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(DB);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Old: WebUser comingUser = DB.UserTable.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                // userManager searches the user according to  username and password recieved from the model.
                ApplicationUser comingUser = userManager.Find(model.UserName, model.Password);

                if (comingUser != null)
                {
                    // Old: Session["UserInfo"] = comingUser;
                    // The structure to control the entry and exit processes. The structure that encodes and decodes the password is itself.
                    IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;

                    // We create the AuthenticationProperties object for the details of the Authentication process.
                    AuthenticationProperties authProperty = new AuthenticationProperties();

                    // We pass the hash of the current password to this, and it does its own action.
                    // ApplicationCookie is an authentication type and is set in the Startup's Configuration.
                    // Using the userManager object, a ClaimsIdentity object is created that accepts an ApplicationCookie for this user.
                    ClaimsIdentity claims = userManager.CreateIdentity(comingUser, "ApplicationCookie");

                    // By assigning the RememberMe value of the model to the IsPersistent property, we ensure that the session is always on or off.
                    authProperty.IsPersistent = model.RememberMe;

                    // Finally, we complete the login process by calling the SignIn method of the authentication manager.
                    auth.SignIn(authProperty, claims);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "There is no such  user.";

                    return View(model);
                }
            }
            else
            {
                return View(model); // When the model is missing, it leaves the login stage, but returns with the model data on it.
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Old: WebUser insertedUser = new WebUser()
                ApplicationUser comingUser = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName
                    // Old:WebRolId = 2	// 2: user 
                };

                // Old: DB.UserTable.Add(insertedUser);
                // Old: DB.SaveChanges();

                IdentityResult Iresult = userManager.Create(comingUser, model.Password);

                if (Iresult.Succeeded)
                {
                    // Old: up, in comingUser creation.
                    // We will assign a Role named User.
                    userManager.AddToRole(comingUser.Id, "User");

                    return RedirectToAction("Login", "Account");
                }
            }

            return View(model);
        }

        // By using [Authorize] annotation, I prevent this action from being accessed without authenticate. 
        // In fact, this shows us that the access of a user who does not log in or wants to enter a page 
        // without authorization is blocked by annotation. 
        // It is very easy to manage. When we look, logged in users need to logout, thanks to this annotation, 
        // we prevented users who are not logged in from accessing this page.
        [Authorize]
        public ActionResult LogOut()
        {
            // Old: Session["UserInfo"] = null;
            // The structure to control the entry and exit processes. The structure that encodes and decodes the password is itself.
            IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;	
            auth.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Home");
        }
    }
}
