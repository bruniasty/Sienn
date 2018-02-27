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

        public IProductRepository<Product> ProductRepository => this.productRepository ?? (this.productRepository = new ProductRepository<Product>(this.context, this.mapper));

        public IGenericRepository<Category> CategoryRepository => this.categoryRepository ?? (this.categoryRepository = new GenericRepository<Category>(this.context));

        public IGenericRepository<Entities.Type> TypeRepository => this.typeRepository ?? (this.typeRepository = new GenericRepository<Entities.Type>(this.context));

        public IGenericRepository<Unit> UnitRepository => this.unitRepository ?? (this.unitRepository = new GenericRepository<Unit>(this.context));
        
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