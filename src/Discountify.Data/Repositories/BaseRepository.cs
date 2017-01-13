using Discountify.Models;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discountify.Data.Repositories
{
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
            throw new NotImplementedException();
        }

        public TEntity Create(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            return this.discountifyContext.Add(entity).Entity;
        }

        public void Update(TEntity entity)
        {
            EnsureArg.IsNotNull(entity, "entity");

            this.discountifyContext.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
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
