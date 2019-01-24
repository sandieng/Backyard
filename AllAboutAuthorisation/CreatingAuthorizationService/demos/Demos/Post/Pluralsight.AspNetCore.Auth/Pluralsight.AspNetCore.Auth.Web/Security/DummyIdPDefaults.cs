using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Security
{
    public static class DummyIdPDefaults
    {
        public static readonly string AuthenticationScheme = "DummyIdP";
        public static readonly string DisplayName = "Dummy Identity Provider";
    }
}
