using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Pluralsight.AspNetCore.Auth.Web.Services
{
    public class ProfileClaimsTransformation : IClaimsTransformation
    {
        private IProfileService _profileService;

        public ProfileClaimsTransformation(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identities.FirstOrDefault(x => x.IsAuthenticated);
            if (identity == null)
            {
                return principal;
            }

            var idClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var profile = await _profileService.GetUserProfileAsync(idClaim.Value);
            if (profile == null)
            {
                return principal;
            }

            var claims = new List<Claim> {
                idClaim,
                new Claim(ClaimTypes.GivenName, profile.Firstname, ClaimValueTypes.String, "ProfileClaimsTransformation"),
                new Claim(ClaimTypes.Surname, profile.LastName, ClaimValueTypes.String, "ProfileClaimsTransformation"),
                new Claim(ClaimTypes.Name, profile.Firstname + " " + profile.LastName, ClaimValueTypes.String, "ProfileClaimsTransformation")
            };
            claims.AddRange(profile.Roles.Select(x => new Claim(ClaimTypes.Role, x, ClaimValueTypes.String, "ProfileClaimsTransformation")));
            var newIdentity = new ClaimsIdentity(claims, identity.AuthenticationType);
            return new ClaimsPrincipal(newIdentity);
        }
    }
}
