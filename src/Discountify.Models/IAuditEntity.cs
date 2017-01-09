namespace Discountify.Models
{
    using System;

    interface IAuditEntity
    {
        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime LastModifiedAt { get; set; }

        string LastModifiedBy { get; set; }

        bool IsDeleted { get; set; }
    }
}
