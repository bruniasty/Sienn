using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Category> CategoryRepository { get; }
        ProductRepository<Product> ProductRepository { get; }
        GenericRepository<Type> TypeRepository { get; }
        GenericRepository<Unit> UnitRepository { get; }

        void Dispose();
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
}