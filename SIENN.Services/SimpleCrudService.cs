using System.Collections.Generic;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.UnitOfWork;

namespace SIENN.Services
{
    public class SimpleCrudService<T> : ISimpleCrudService<T> where T : class
    {
        public SimpleCrudService(StoreDbContext dbContext, IMapper mapper)
        {
            this.UnitOfWork = new UnitOfWork(dbContext, mapper);
        }

        public IEnumerable<T> GetAll()
        {
            return this.UnitOfWork.GetRepository<T>().GetAll();
        }

        public T Get(int id)
        {
            return this.UnitOfWork.GetRepository<T>().Get(id);
        }

        public void Create(T t)
        {
            this.UnitOfWork.GetRepository<T>().Add(t);
            this.UnitOfWork.Save();
        }

        public void Update(T t)
        {
            this.UnitOfWork.GetRepository<T>().Update(t);
            this.UnitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.UnitOfWork.GetRepository<T>().Remove(id);
            this.UnitOfWork.Save();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}