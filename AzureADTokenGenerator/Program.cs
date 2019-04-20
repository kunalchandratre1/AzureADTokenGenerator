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
            var clientCredential = new ClientCredential("bef5d8be-6567-424f-95d4-af990a3a8d53", "S0R/EI6LtPqRI3VtdtV/3ej1ZWUt49+pidVf/Bd4W1U=");
            //var clientCredential = new ClientCredential("Your Azure AD Application ID", "Azure AD Application secret key");
            var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47");
            //var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/YourAzureADTenantID");
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


