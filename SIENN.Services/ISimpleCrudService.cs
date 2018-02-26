using System.Collections.Generic;
using SIENN.DbAccess.Repositories;

namespace SIENN.Services
{
    public interface ISimpleCrudService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
        UnitOfWork UnitOfWork { get; }
    }
}