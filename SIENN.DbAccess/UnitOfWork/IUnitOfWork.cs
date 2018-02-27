using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IProductRepository<Product> ProductRepository { get; }
        IGenericRepository<Type> TypeRepository { get; }
        IGenericRepository<Unit> UnitRepository { get; }

        void Dispose();
        void Save();
    }
}