using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Pluralsight.AspNetCore.Auth.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddAuthentication(options => {
                options.DefaultChallengeScheme = "oidc";
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = "oidc";
            })
                .AddOpenIdConnect("oidc", options => {
                    options.Authority = "https://localhost:44371";
                    options.ClientId = "WebApp";
                    options.ClientSecret = "MySecret";
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.Scope.Add("DemoApi");
                    options.Scope.Add("offline_access");
                    options.SignedOutRedirectUri = "/";
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                })
                .AddCookie();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, 44343));

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
