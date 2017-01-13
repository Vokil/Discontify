namespace Discountify.Models
{
    public class City : BaseAuditedEntity
    {
        public string Name { get; set; }

        public virtual Province Province  { get; set; }
    }
}
