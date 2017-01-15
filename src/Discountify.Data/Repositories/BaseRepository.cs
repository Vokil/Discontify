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


        /// <summary>
        /// Delete optimized works faster than usual Delete method.
        /// The usage should be as followed: 
        /// 0) You dont have to any make previous queries for getting the TEntity from the DB.
        /// 1) Create instance ot TEntity with only setted Id (The paramater is usually received in MVC controller)
        /// 2) Pass already created TEntity to this method
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteOptimized(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            this.discountifyContext.Entry(entity).State = EntityState.Deleted;
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
