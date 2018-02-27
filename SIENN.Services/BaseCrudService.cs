using System.Collections.Generic;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.UnitOfWork;
using SIENN.Services.Interfaces;

namespace SIENN.Services
{
    public abstract class BaseCrudService<T> : IBaseCrudService<T> where T : class
    {
        protected BaseCrudService(StoreDbContext dbContext, IMapper mapper)
        {
            this.UnitOfWork = new UnitOfWork(dbContext, mapper);
        }

        protected IUnitOfWork UnitOfWork { get; }

        public abstract IEnumerable<T> GetAll();

        public abstract T Get(int id);

        public abstract void Create(T t);

        public abstract void Update(T t);

        public abstract void Delete(int id);
    }
}