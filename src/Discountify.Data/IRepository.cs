namespace Discountify.Data
{
    public interface IRepository<TEntity>
    {
        TEntity Get(object id);

        TEntity Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
