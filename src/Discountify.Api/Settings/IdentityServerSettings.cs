namespace Discountify.Api.Settings
{
    public class IdentityServerSettings
    {
        public string Authority { get; set; }

        public string ApiName { get; set; }

        public bool RequireHttpsMetadata { get; set; }
    }
}
