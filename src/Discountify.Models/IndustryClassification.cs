namespace Discountify.Models
{
    public class IndustryClassification : BaseAuditedEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IndustryClassification Parrent { get; set; }
    }
}
