using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Pluralsight.AspNetCore.Auth.Encryption;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Pluralsight.AspNetCore.Auth.Web.Security
{
    public class DummyIdPHandler : RemoteAuthenticationHandler<DummyIdPOptions>, IAuthenticationSignOutHandler
    {
        public DummyIdPHandler(IOptionsMonitor<DummyIdPOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            var returnUrl = new Uri(CurrentUri).PathAndQuery;
            if (properties != null && !string.IsNullOrEmpty(properties.RedirectUri))
            {
                returnUrl = properties.RedirectUri;
            }
            var redirectUri = Options.IdPUri.TrimEnd('/');
            redirectUri += "/SignOut?returnUrl=" + BuildRedirectUri(returnUrl);

            Context.Response.Redirect(redirectUri);
            return Task.CompletedTask;
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            if (string.IsNullOrEmpty(properties.RedirectUri))
            {
                properties.RedirectUri = CurrentUri;
            }
            var callbackUri = BuildRedirectUri(Options.CallbackPath + "?redirectUri=" + properties.RedirectUri);
            Context.Response.Redirect(Options.IdPUri + "/SignIn?returnUrl=" + UrlEncoder.Encode(callbackUri));
            return Task.CompletedTask;
        }

        protected override Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            if (!Request.Form.ContainsKey("payload"))
            {
                return Task.FromResult(HandleRequestResult.Fail("The response didn't contain the required payload"));
            }
            var payload = Request.Form["payload"];

            var redirectUri = "/";
            if (Request.Query.ContainsKey("redirectUri"))
            {
                redirectUri = Request.Query["redirectUri"];
            }

            var json = EncryptionHelper.Decrypt(payload, Options.DecryptionKey);
            var user = JObject.Parse(json);
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Value<string>("username"), ClaimValueTypes.String, ClaimsIssuer),
                new Claim(ClaimTypes.Name, user.Value<string>("username"), ClaimValueTypes.String, ClaimsIssuer)
            };
            var roles = (JArray)user["roles"];
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x.Value<string>(), ClaimValueTypes.String, ClaimsIssuer)));
            var identity = new ClaimsIdentity(claims, ClaimsIssuer);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties { RedirectUri = redirectUri }, Scheme.Name);
            return Task.FromResult(HandleRequestResult.Success(ticket));
        }
    }
}
