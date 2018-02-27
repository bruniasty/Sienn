using System.Collections.Generic;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.Services
{
    public class CategoryService : BaseCrudService<Category>, ICategoryService<Category>
    {
        public CategoryService(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Category> GetAll()
        {
            return this.UnitOfWork.CategoryRepository.GetAll();
        }

        public override Category Get(int id)
        {
            return this.UnitOfWork.CategoryRepository.Get(id);
        }

        public override void Create(Category t)
        {
            this.UnitOfWork.CategoryRepository.Create(t);
            this.UnitOfWork.Save();
        }

        public override void Update(Category t)
        {
            this.UnitOfWork.CategoryRepository.Update(t);
            this.UnitOfWork.Save();
        }

        public override void Delete(int id)
        {
            this.UnitOfWork.CategoryRepository.Delete(id);
            this.UnitOfWork.Save();
        }
    }
}