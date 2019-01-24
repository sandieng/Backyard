using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Pluralsight.AspNetCore.Auth.Web.Security;

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
                options.DefaultChallengeScheme = DummyIdPDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = DummyIdPDefaults.AuthenticationScheme;
            })
                .AddDummyIdP(options => {
                    options.IdPUri = "https://localhost:44357/";
                    options.DecryptionKey = "MyVerySecretKey";
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
