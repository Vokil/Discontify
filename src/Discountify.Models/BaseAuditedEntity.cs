namespace Discountify.Models
{
    using System;

    public abstract class BaseAuditedEntity : BaseEntity, IAuditEntity
    {
        protected BaseAuditedEntity() { }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
