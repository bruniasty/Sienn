using System.Collections.Generic;

namespace SIENN.Services.Interfaces
{
    public interface IBaseCrudService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}