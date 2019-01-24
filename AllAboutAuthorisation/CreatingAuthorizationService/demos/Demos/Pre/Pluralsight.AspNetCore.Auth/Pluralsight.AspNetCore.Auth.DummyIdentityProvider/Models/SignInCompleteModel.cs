namespace Pluralsight.AspNetCore.Auth.DummyIdentityProvider.Models
{
    public class SignInCompleteModel
    {
        public string RedirectUri { get; set; }
        public string Payload { get; set; }
    }
}
