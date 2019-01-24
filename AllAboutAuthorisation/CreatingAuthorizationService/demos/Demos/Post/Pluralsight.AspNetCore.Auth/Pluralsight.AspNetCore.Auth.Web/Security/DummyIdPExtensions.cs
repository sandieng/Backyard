using Microsoft.AspNetCore.Authentication;
using Pluralsight.AspNetCore.Auth.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DummyIdPExtensions
    {
        public static AuthenticationBuilder AddDummyIdP(this AuthenticationBuilder builder)
        {
            return builder.AddRemoteScheme<DummyIdPOptions, DummyIdPHandler>(DummyIdPDefaults.AuthenticationScheme, DummyIdPDefaults.DisplayName, x => { });
        }
        public static AuthenticationBuilder AddDummyIdP(this AuthenticationBuilder builder, Action<DummyIdPOptions> configureOptions)
        {
            return builder.AddRemoteScheme<DummyIdPOptions, DummyIdPHandler>(DummyIdPDefaults.AuthenticationScheme, DummyIdPDefaults.DisplayName, configureOptions);
        }
        public static AuthenticationBuilder AddDummyIdP(this AuthenticationBuilder builder, string authenticationScheme, Action<DummyIdPOptions> configureOptions)
        {
            return builder.AddRemoteScheme<DummyIdPOptions, DummyIdPHandler>(authenticationScheme, DummyIdPDefaults.DisplayName, configureOptions);
        }
        public static AuthenticationBuilder AddDummyIdP(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<DummyIdPOptions> configureOptions)
        {
            return builder.AddRemoteScheme<DummyIdPOptions, DummyIdPHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
