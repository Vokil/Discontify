namespace Discountify.Data.Repositories
{
    using Discountify.Models;
    using EnsureThat;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity: BaseEntity, IDeletable
    {
        private readonly IDiscountifyContext discountifyContext;

        public BaseRepository(IDiscountifyContext discountifyContext)
        {
            EnsureArg.IsNotNull(discountifyContext, "discountifyContext");

            this.discountifyContext = discountifyContext;
        }

        public TEntity Get(object id)
        {
            EnsureArg.IsNotNull(id, "id");

            return this.discountifyContext.Find<TEntity>(id);
        }

        public TEntity Create(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            return this.discountifyContext.Add(entity).Entity;
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            EnsureArg.IsNotNull(entities, "entities");
            EnsureArg.HasItems<TEntity>(entities.ToArray(), "entities");

            this.discountifyContext.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            this.discountifyContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            EnsureArg.IsNotNull(entities, "entities");
            EnsureArg.HasItems<TEntity>(entities.ToArray(), "entities");

            this.discountifyContext.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            this.discountifyContext.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            EnsureArg.IsNotNull(entities, "entities");
            EnsureArg.HasItems<TEntity>(entities.ToArray(), "entities");

            this.discountifyContext.RemoveRange(entities);
        }

        protected IQueryable<TEntity> Collection
        {
            get
            {
                return this.DbSet.Where(x => !x.IsDeleted);
            }
        }

        private DbSet<TEntity> DbSet
        {
            get
            {
                return this.discountifyContext.Set<TEntity>();
            }
        }
    }
}
