namespace Discountify.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DiscountifyContext : DbContext
    {
        public DiscountifyContext()
        {

        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Discount> Discounts { get; set; }
    }
}
