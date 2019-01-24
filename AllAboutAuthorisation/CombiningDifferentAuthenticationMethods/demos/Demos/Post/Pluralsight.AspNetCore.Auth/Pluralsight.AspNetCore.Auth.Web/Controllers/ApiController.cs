using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Pluralsight.AspNetCore.Auth.Web.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApiController : Controller
    {
        [Route("user")]
        [HttpGet]
        public IActionResult GetUserInformation()
        {
            return Ok(new {
                id = User.FindFirst("sub").Value,
                username = User.Identity.Name
            });
        }
    }
}