namespace Discountify.Models
{
    public class Discount : BaseAuditedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public string Type { get; set; }

        public virtual Card Card { get; set; }

        public virtual Venue Venue { get; set; }
    }
}