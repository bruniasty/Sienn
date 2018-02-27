using System.Collections.Generic;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.Services
{
    public class TypeService : BaseCrudService<Type>, ITypeService<Type>
    {
        public TypeService(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Type> GetAll()
        {
            return this.UnitOfWork.TypeRepository.GetAll();
        }

        public override Type Get(int id)
        {
            return this.UnitOfWork.TypeRepository.Get(id);
        }

        public override void Create(Type t)
        {
            this.UnitOfWork.TypeRepository.Create(t);
            this.UnitOfWork.Save();
        }

        public override void Update(Type t)
        {
            this.UnitOfWork.TypeRepository.Update(t);
            this.UnitOfWork.Save();
        }

        public override void Delete(int id)
        {
            this.UnitOfWork.TypeRepository.Delete(id);
            this.UnitOfWork.Save();
        }
    }
}