using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WinOwin.Auth
{
    public class AuthMan
    {
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public void IdentitySignIn(string userID)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, "s@t.i"));
            claims.Add(new Claim(ClaimTypes.Name, HttpContext.Current.User.Identity.Name));
            //var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.MobilePhone, "8989481081"));
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
        }
    }
}