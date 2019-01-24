using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "B2C_1_sign_up_in";
            })
                .AddOpenIdConnect("B2C_1_sign_up", options => SetOptionsForOpenIdConnectPolicy("B2C_1_sign_up", options))
                .AddOpenIdConnect("B2C_1_sign_in", options => SetOptionsForOpenIdConnectPolicy("B2C_1_sign_in", options))
                .AddOpenIdConnect("B2C_1_sign_up_in", options => SetOptionsForOpenIdConnectPolicy("B2C_1_sign_up_in", options))
                .AddOpenIdConnect("B2C_1_edit_profile", options => SetOptionsForOpenIdConnectPolicy("B2C_1_edit_profile", options))
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

        public void SetOptionsForOpenIdConnectPolicy(string policy, OpenIdConnectOptions options)
        {
            options.MetadataAddress = "https://login.microsoftonline.com/### ADD TENANT NAME HERE ###/v2.0/.well-known/openid-configuration?p=" + policy;
            options.ClientId = "### ADD APPLICATION ID HERE ###";
            options.ResponseType = OpenIdConnectResponseType.IdToken;
            options.CallbackPath = "/signin/" + policy;
            options.SignedOutCallbackPath = "/signout/" + policy;
            options.SignedOutRedirectUri = "/";
            options.TokenValidationParameters.NameClaimType = "name";
        }
    }
}
