using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIENN.DbAccess.Repositories
{
    public interface IStoreRepository<T, TKey> : IGenericRepository<T> where T : class
        where TKey : IEquatable<TKey>
    {

        Task<DbSet<T>> List();
        Task<T> Get(TKey id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(TKey id);
    }
}