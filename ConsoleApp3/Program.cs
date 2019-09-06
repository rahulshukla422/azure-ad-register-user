using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientId = "your client id ";
            string clientSecret = "your client secret";
            string tenantID = "your azure ad tanant/ directory id";

            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                                                                            .Create(clientId)
                                                                            .WithTenantId(tenantID)
                                                                            .WithClientSecret(clientSecret)
                                                                            .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var invitation = new Invitation
            {
                InvitedUserEmailAddress = "rahulshukla422@gmail.com",
                InviteRedirectUrl = "https://yourapplication.com"
            };

            graphClient.Invitations
               .Request()
               .AddAsync(invitation).GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
