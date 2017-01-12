namespace Discountify.Data
{
    using Microsoft.EntityFrameworkCore;

    public interface IDiscountifyContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
