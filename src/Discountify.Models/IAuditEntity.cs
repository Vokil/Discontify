namespace Discountify.Models
{
    using System;

    public interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime LastModifiedAt { get; set; }

        string LastModifiedBy { get; set; }
    }
}
