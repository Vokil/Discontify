namespace Discountify.Identity.Settings
{
    using System.Collections.Generic;

    public class ClientSettings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int AccessTokenLifetime { get; set; }

        public ICollection<string> AllowedScopes { get; set; }

        public ICollection<string> Secrets { get; set; }
    }
}
