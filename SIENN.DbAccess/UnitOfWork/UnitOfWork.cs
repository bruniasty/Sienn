using System;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly StoreDbContext context;
        private readonly IMapper mapper;

        private  ProductRepository<Product> productRepository;
        private  GenericRepository<Category> categoryRepository;
        private  GenericRepository<Entities.Type> typeRepository;
        private  GenericRepository<Unit> unitRepository;

        private bool disposed;

        public UnitOfWork(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ProductRepository<Product> ProductRepository => this.productRepository ?? (this.productRepository = new ProductRepository<Product>(this.context, this.mapper));

        public GenericRepository<Category> CategoryRepository => this.categoryRepository ?? (this.categoryRepository = new GenericRepository<Category>(this.context));

        public GenericRepository<Entities.Type> TypeRepository => this.typeRepository ?? (this.typeRepository = new GenericRepository<Entities.Type>(this.context));

        public GenericRepository<Unit> UnitRepository => this.unitRepository ?? (this.unitRepository = new GenericRepository<Unit>(this.context));

        public IGenericRepository<T> GetRepository<T>() where T: class
        {
            var repositoryType = typeof(T);
            if (repositoryType == typeof(Product))
            {
                return (IGenericRepository<T>)this.ProductRepository;
            }

            if (repositoryType == typeof(Category))
            {
                return (IGenericRepository<T>)this.CategoryRepository;
            }

            if (repositoryType == typeof(Unit))
            {
                return (IGenericRepository<T>)this.UnitRepository;
            }

            if (repositoryType == typeof(Entities.Type))
            {
                return (IGenericRepository<T>)this.TypeRepository;
            }

            return null;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}