using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var disco = await DiscoveryClient.GetAsync("https://localhost:44371");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "WebApp", "MySecret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("DemoApi");

            object model;
            if (tokenResponse.IsError)
            {
                model = "Error...could not get access token for API";
            }
            else
            {
                var client = new HttpClient();
                client.SetBearerToken(tokenResponse.AccessToken);
                var response = await client.GetAsync("https://localhost:44393/api/text/welcome");
                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    model = "Error...could not retrieve text";
                }
            }

            return View(model);
        }

        [Route("spa")]
        public IActionResult Spa()
        {
            return View();
        }
    }
}
