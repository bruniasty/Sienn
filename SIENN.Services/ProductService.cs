using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.DTO;
using SIENN.DbAccess.Entities;
using SIENN.Services.Interfaces;

namespace SIENN.Services
{
    public class ProductService : BaseCrudService<Product>, IProductService<Product>
    {
        public ProductService(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            return this.UnitOfWork.ProductRepository.GetAll();
        }

        public override Product Get(int id)
        {
            return this.UnitOfWork.ProductRepository.Get(id);
        }

        public override void Create(Product t)
        {
            this.UnitOfWork.ProductRepository.Create(t);
            this.UnitOfWork.Save();
        }

        public override void Update(Product t)
        {
            this.UnitOfWork.ProductRepository.Update(t);
            this.UnitOfWork.Save();
        }

        public override void Delete(int id)
        {
            this.UnitOfWork.ProductRepository.Delete(id);
            this.UnitOfWork.Save();
        }
        
        public List<ProductDto> GetAvailableProducts(int start, int count)
        {
            return this.UnitOfWork.ProductRepository.GetRange(start, count, true).ToList();
        }
        
        public List<Product> GetProducts(int start, int count)
        {
            return this.UnitOfWork.ProductRepository.GetRange(start, count).ToList();
        }
        
        public List<ProductInfoDto> GetProductsInfo(int start, int count)
        {
            return this.UnitOfWork.ProductRepository.GetRangeInfo(start, count).ToList();
        }
        
        public List<ProductDto> GetFiltered(string type = null, string category = null, string unit = null)
        {
            return this.UnitOfWork.ProductRepository.GetFiltered(type, category, unit).ToList();
        }
    }
}