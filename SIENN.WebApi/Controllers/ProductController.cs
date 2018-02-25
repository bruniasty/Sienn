using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;
using SIENN.Services.DTO;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : SimpleCrudController<Product, int>
    {
        private readonly IMapper mapper;
        private readonly ProductRepository<Product, int> productRepository;

        public ProductController(StoreDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
            this.productRepository = new ProductRepository<Product, int>(dbContext);

        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductDto> GetAvailableProducts(int start, int count)
        {
            var products = this.productRepository.GetRange(start, count, true).ToList();
            return this.mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductDto> GetProducts(int start, int count)
        {
            var products = this.productRepository.GetRange(start, count).ToList();
            return this.mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        [HttpGet]
        [Route("[action]/{start:int:min(0)}/{count:int:min(1):max(50)}")]
        public List<ProductInfoDto> GetProductsInfo(int start, int count)
        {
            var products = this.productRepository.GetRange(start, count).ToList();
            var result = new List<ProductInfoDto>();
            foreach (var product in products)
            {
                result.Add(new ProductInfoDto(product));
            }

            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public List<ProductDto> GetFiltered(string type = null, string category = null, string unit = null)
        {
            var products = this.productRepository.GetFiltered(type, category, unit).ToList();
            return this.mapper.Map<List<Product>, List<ProductDto>>(products);
        }
    }
}