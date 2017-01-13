namespace Discountify.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser, IAuditEntity, IDeletable
    {
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsMale { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
