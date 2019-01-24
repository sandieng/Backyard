using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Pluralsight.AspNetCore.Auth.Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "B2C_1_sign_up");
        }

        [Route("signout")]
        [HttpPost]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var scheme = User.FindFirst("tfp").Value;
            await HttpContext.SignOutAsync(scheme);
        }

        [Route("signin")]
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "B2C_1_sign_in");
        }

        [Route("editprofile")]
        public IActionResult EditProfile()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "B2C_1_edit_profile");
        }
    }
}