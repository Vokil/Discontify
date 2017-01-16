namespace Discountify.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
    {
        TEntity Get(object id);

        TEntity Create(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        int Save();

        Task<int> SaveAsync();
    }
}
