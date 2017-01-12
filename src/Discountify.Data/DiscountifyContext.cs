namespace Discountify.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DiscountifyContext : DbContext, IDiscountifyContext
    {
        public DiscountifyContext(DbContextOptions<DiscountifyContext> options)
            : base(options) { }

        public DiscountifyContext() {}

        public DbSet<Card> Cards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
