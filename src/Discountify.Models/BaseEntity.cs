namespace Discountify.Models
{
    using System;

    public abstract class BaseEntity : IDeletable
    {
        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
