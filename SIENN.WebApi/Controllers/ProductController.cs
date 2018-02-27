using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.DTO;
using SIENN.DbAccess.Entities;
using SIENN.Services;
using SIENN.Services.Interfaces;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : SimpleCrudController<Product, IProductService<Product>>
    {
        public ProductController(StoreDbContext dbContext, IMapper mapper, IProductService<Product> service) : base(service)
        {
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductDto> GetAvailableProducts(int start, int count)
        {
            return this.Service.GetAvailableProducts(start, count);
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<Product> GetProducts(int start, int count)
        {
            return this.Service.GetProducts(start, count);
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductInfoDto> GetProductsInfo(int start, int count)
        {
            return this.Service.GetProductsInfo(start, count);
        }

        [HttpGet]
        [Route("[action]")]
        public List<ProductDto> GetFiltered(string type = null, string category = null, string unit = null)
        {
            return this.Service.GetFiltered(type, category, unit);
        }
    }
}