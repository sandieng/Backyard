using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("DemoApi", new [] { "name" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client
                {
                    ClientId = "WebApp",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = new [] { new Secret("MySecret".Sha256()) },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "DemoApi"
                    },
                    RedirectUris = { "https://localhost:44343/signin-oidc" },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44343/signout-callback-oidc"
                    },
                    AllowOfflineAccess = true,
                    RequireConsent = false
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "ZeroKoll",
                    Password = "test",
                    Claims = new []
                    {
                        new Claim("name", "ZeroKoll")
                    }
                }
            };
        }
    }
}
