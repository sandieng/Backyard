using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralsight.AspNetCore.Auth.Web.Security
{
    public class DummyIdPOptions : RemoteAuthenticationOptions
    {
        public DummyIdPOptions()
        {
            CallbackPath = "/signin-dummyidp";
        }

        public string IdPUri { get; set; }
        public string DecryptionKey { get; set; }
    }
}
