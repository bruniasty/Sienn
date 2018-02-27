using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.DTO;
using SIENN.DbAccess.Entities;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : SimpleCrudController<Product>
    {
        public ProductController(StoreDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductDto> GetAvailableProducts(int start, int count)
        {
            return this.Service.UnitOfWork.ProductRepository.GetRange(start, count, true).ToList();
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductDto> GetProducts(int start, int count)
        {
            return this.Service.UnitOfWork.ProductRepository.GetRange(start, count).ToList();
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductInfoDto> GetProductsInfo(int start, int count)
        {
            return this.Service.UnitOfWork.ProductRepository.GetRangeInfo(start, count).ToList();
        }

        [HttpGet]
        [Route("[action]")]
        public List<ProductDto> GetFiltered(string type = null, string category = null, string unit = null)
        {
            return this.Service.UnitOfWork.ProductRepository.GetFiltered(type, category, unit).ToList();
        }
    }
}