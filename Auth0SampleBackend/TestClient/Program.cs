using System;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://externallogin.au.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"zX05PFukH71mUwO7FuXzsJSNjjvUbGm1\",\"client_secret\":\"6U6IioM9qKmtnH-T4zcgSTeAa7EW5TvADUZXJ2LCyCwXoQZBYmbelY-1RSP5e5JW\",\"audience\":\"https://vuecontacts/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
