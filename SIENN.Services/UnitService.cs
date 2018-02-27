using System.Collections.Generic;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.Services
{
    public class UnitService : BaseCrudService<Unit>, IUnitService<Unit>
    {
        public UnitService(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Unit> GetAll()
        {
            return this.UnitOfWork.UnitRepository.GetAll();
        }

        public override Unit Get(int id)
        {
            return this.UnitOfWork.UnitRepository.Get(id);
        }

        public override void Create(Unit t)
        {
            this.UnitOfWork.UnitRepository.Create(t);
            this.UnitOfWork.Save();
        }

        public override void Update(Unit t)
        {
            this.UnitOfWork.UnitRepository.Update(t);
            this.UnitOfWork.Save();
        }

        public override void Delete(int id)
        {
            this.UnitOfWork.UnitRepository.Delete(id);
            this.UnitOfWork.Save();
        }
    }
}