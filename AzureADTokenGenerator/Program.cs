using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADTokenGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientCredential = new ClientCredential("Your Azure AD Application ID", "Azure AD Application secret key");            
            var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/YourAzureADTenantID");
            var result = authenticationContext.AcquireTokenAsync("https://management.azure.com/", clientCredential).Result;

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            Console.WriteLine("Bearer " + result.AccessToken);

            Console.ReadLine();
        }
    }
}


