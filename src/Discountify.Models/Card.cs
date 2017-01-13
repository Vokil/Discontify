namespace Discountify.Models
{
    using System.Collections.Generic;

    public class Card : BaseAuditedEntity
    {
        public Card()
        {
            this.Discounts = new HashSet<Discount>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
