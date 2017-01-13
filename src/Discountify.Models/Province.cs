namespace Discountify.Models
{
    public class Province : BaseAuditedEntity
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
