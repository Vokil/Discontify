namespace Discountify.Models
{
    public class Card : BaseAuditedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual string AccountId { get; set; }
    }
}
