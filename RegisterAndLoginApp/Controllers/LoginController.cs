using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using NLog;
using RegisterAndLoginApp.Utility;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            //MyLogger.GetInstance().Info("Entering the ProcessLogin method");
            //MyLogger.GetInstance().Info("Parameter: " + user.toString());
            SecurityService securityService = new();

            if(user.UserName == "Bill Gates")
            {
                System.Diagnostics.Debugger.Break();
            }

            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login success.");

                HttpContext.Session.SetString("username", user.UserName);

                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login failure.");

                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me.");
        }
    }
}
