using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.Services
{
    public interface ISimpleCrudService<T, in TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {
        Task<IQueryable<T>> List();
        Task<T> Get(TKey id);
        Task Create(T t);
        Task Update(T t);
        Task Delete(TKey id);
    }
}