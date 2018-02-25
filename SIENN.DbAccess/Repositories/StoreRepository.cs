using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SIENN.DbAccess.Context;

namespace SIENN.DbAccess.Repositories
{
    public class StoreRepository<T, TKey> : GenericRepository<T>, IStoreRepository<T, TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {

        public StoreRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<DbSet<T>> List()
        {
            return await Task.Run(() => this.entities);
        }

        public virtual async Task<T> Get(TKey id)
        {
            return await this.entities.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await this.entities.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            this.entities.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            EntityEntry dbEntityEntry = this.context.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.entities.Attach(entity);
                this.entities.Remove(entity);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            var entity = await this.Get(id);
            if (entity == null) return;
            await this.Delete(entity);
        }
    }
}