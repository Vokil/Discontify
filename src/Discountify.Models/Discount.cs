namespace Discountify.Models
{
    public class Discount : BaseAuditedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public virtual string  CardId { get; set; }
    }
}