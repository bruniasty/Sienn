using System;
using System.Linq;
using System.Threading.Tasks;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Repositories;

namespace SIENN.Services
{
    public class SimpleCrudService<T, TKey> : ISimpleCrudService<T, TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {
        private readonly IStoreRepository<T, TKey> repository;

        public SimpleCrudService(StoreDbContext dbContext)
        {
            this.repository = new StoreRepository<T, TKey>(dbContext);
        }

        public async Task<IQueryable<T>> List()
        {
            return await this.repository.List();
        }

        public async Task<T> Get(TKey id)
        {
            return await this.repository.Get(id);
        }

        public async Task Create(T t)
        {
            await this.repository.Create(t);
        }

        public async Task Update(T t)
        {
            await this.repository.Update(t);
        }

        public async Task Delete(TKey id)
        {
            await this.repository.Delete(id);
        }
    }
}