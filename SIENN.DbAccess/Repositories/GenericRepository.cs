using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> entities;
        protected DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return this.entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.entities.ToList();
        }

        public virtual IEnumerable<TEntity> GetRange(int start, int count)
        {
            return this.entities.Skip(start).Take(count).ToList();
        }

        public virtual IEnumerable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate).Skip(start).Take(count).ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate);
        }

        public virtual int Count()
        {
            return this.entities.Count();
        }

        public virtual void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = this.Get(id);
            if (entity == null) return;
            this.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
