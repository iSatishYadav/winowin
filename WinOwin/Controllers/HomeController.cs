using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WinOwin.Auth;  

namespace WinOwin.Controllers
{
    //[Authorize(Users="Work\\Satish")]
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new AuthMan().IdentitySignIn(Request.GetOwinContext().Authentication.User.Identity.Name);
            return View();
        }

        public ActionResult About()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            var identity = (ClaimsIdentity) Request.GetOwinContext().Authentication.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            ViewBag.Message = claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}