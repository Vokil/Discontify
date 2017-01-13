namespace Discountify.Models
{
    using System.Collections.Generic;

    public class Venue : BaseAuditedEntity
    {
        public Venue()
        {
            this.Discounts = new HashSet<Discount>();
        }

        public string Name { get; set; }

        public int Rating { get; set; }

        public string WebsiteUrl { get; set; }

        public string Phone { get; set; }

        public virtual Address Address { get; set; }

        public virtual IndustryClassification IndustryClassification { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
