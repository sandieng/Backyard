using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Pluralsight.AspNetCore.Auth.Web.Services;
using System.Collections.Generic;

namespace Pluralsight.AspNetCore.Auth.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(new RequireHttpsAttribute());
            });
            
            services.AddSingleton<IUserService>(new DummyUserService(GetUsers()));
            services.AddSingleton<IPassportService>(new DummyPassportService(GetPassports()));
            services.AddSingleton<IVisaService>(new DummyVisaService(GetVisaHolders()));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options => {
                    options.LoginPath = "/auth/signin";
                });
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

        private static IDictionary<string, (string Password, string DateOfBirth)> GetUsers()
        {
            return new Dictionary<string, (string Password, string DateOfBirth)> {
                { "Chris", ("test", "1980-03-25") },
                { "Bart", ("lisa", "2008-04-15") },
                { "Homer", ("marge", "1970-08-13") }
            };
        }
        private static IDictionary<string, Passport> GetPassports()
        {
            return new Dictionary<string, Passport> {
                { "Chris", new Passport("123456", "2023-05-06", "Sweden") },
                { "Bart", new Passport("456123", "2025-05-06", "USA") },
                { "Homer", new Passport("654321", "2015-02-25", "USA") }
            };
        }
        private static IDictionary<string, string[]> GetVisaHolders()
        {
            return new Dictionary<string, string[]> {
                { "Chris", new[] { "USA" } }
            };
        }
    }
}
