using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Microsoft.Graph.Auth;

namespace MicrosoftGraphGetProfile
{
    class Program
    {
        private const string _clientId = "";
        private const string _tenantId = "";

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            string[] scopes = { "user.read" };
            
            var provider = new InteractiveAuthenticationProvider(app, scopes);
            var client = new GraphServiceClient(provider);
            User me = await client.Me.Request().GetAsync();
            Console.WriteLine($"Display Name:\t{me.DisplayName}");



        }
    }
}
