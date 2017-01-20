namespace Discountify.Identity
{
    using IdentityServer4.Models;
    using Settings;
    using System.Collections.Generic;
    using System.Linq;

    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources(IEnumerable<ApiResourceSettings> collection)
        {
            var apiResources = new HashSet<ApiResource>();

            foreach (var apiResourceSettings in collection)
            {
                apiResources.Add(new ApiResource(apiResourceSettings.Name, apiResourceSettings.DisplayName));
            }

            return apiResources;
        }

        public static IEnumerable<Client> GetClients(IEnumerable<ClientSettings> collection)
        {
            var clients = new HashSet<Client>();

            foreach (var clientSettings in collection)
            {
                var client = new Client
                {
                    //Basics
                    ClientId = clientSettings.Id,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = clientSettings.AllowedScopes,
                    AllowAccessTokensViaBrowser = true,
                    AllowOfflineAccess = true, // Refresh tokens
                    ClientSecrets =
                    {
                        new Secret(clientSettings.Secrets.FirstOrDefault().Sha256())
                    },

                    //Token
                    AccessTokenLifetime = clientSettings.AccessTokenLifetime, 

                    //Consent Screen
                    ClientName = clientSettings.Name
                };

                clients.Add(client);
            }

            return clients;
        }
    }
}
