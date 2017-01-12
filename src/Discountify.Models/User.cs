namespace Discountify.Models
{
    using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class User : IdentityUser, IAuditEntity, IDeletable
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
