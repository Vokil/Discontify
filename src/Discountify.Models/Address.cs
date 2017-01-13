namespace Discountify.Models
{
    public class Address : BaseAuditedEntity
    {
        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public int Floor { get; set; }

        public string Description { get; set; }

        public int PostalCode { get; set; }

        public virtual Geolocation Geolocation { get; set; }

        public virtual District District { get; set; }
    }
}
