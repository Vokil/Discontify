namespace Discountify.Models
{
    public class District : BaseAuditedEntity
    {
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
