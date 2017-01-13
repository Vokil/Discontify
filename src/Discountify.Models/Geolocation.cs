namespace Discountify.Models
{
    public class Geolocation : BaseAuditedEntity
    {
        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
