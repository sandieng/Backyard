using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Pluralsight.AspNetCore.Auth.DummyIdentityProvider.Models;
using Newtonsoft.Json;
using Pluralsight.AspNetCore.Auth.Encryption;
using Microsoft.Extensions.Configuration;

namespace Pluralsight.AspNetCore.Auth.DummyIdentityProvider.Controllers
{
    public class AuthController : Controller
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [Route("signin")]
        public IActionResult SignIn(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                if (User.Identity.IsAuthenticated)
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }

            if (User.Identity.IsAuthenticated)
            {
                return SignInComplete((ClaimsIdentity)User.Identity, returnUrl);
            }

            return View(new SignInModel());
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username.Equals("chris", StringComparison.OrdinalIgnoreCase)
                    && model.Password == "test")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, "ZeroKoll"),
                        new Claim(ClaimTypes.Name, "Chris"),
                        new Claim(ClaimTypes.Role, "User"),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return SignInComplete(identity, model.ReturnUrl);
                }
                ModelState.AddModelError("InvalidCredentials", "Could not verify credentials. Please try again...");
            }
            return View(model);
        }

        [Route("SignOut")]
        public async Task<IActionResult> SignOut(string returnUrl)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(returnUrl);
        }

        private IActionResult SignInComplete(ClaimsIdentity identity, string returnUrl)
        {
            var payload = GetPayload(identity);

            return View("SignInComplete", new SignInCompleteModel
            {
                RedirectUri = returnUrl,
                Payload = payload
            });
        }

        private string GetPayload(ClaimsIdentity identity)
        {
            var user = new
            {
                username = identity.FindFirst(ClaimTypes.NameIdentifier).Value,
                name = identity.Name,
                roles = identity.FindAll(ClaimTypes.Role).Select(x => x.Value)
            };
            var json = JsonConvert.SerializeObject(user);
            return EncryptionHelper.Encrypt(json, _config["encryptionKey"]);
        }
    }
}