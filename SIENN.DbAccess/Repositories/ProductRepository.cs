using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.DTO;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository<T> : GenericRepository<T> where T : class
    {
        private readonly IMapper mapper;

        public ProductRepository(DbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public new ProductDto Get(int id)
        {
            return this.GetProductsQuery().ProjectTo<ProductDto>(this.mapper.ConfigurationProvider).FirstOrDefault(e => e.Id == id);
        }

        public new IEnumerable<ProductDto> GetAll()
        {
            return this.GetProductsQuery().ProjectTo<ProductDto>(this.mapper.ConfigurationProvider).ToList();
        }

        public new IEnumerable<ProductDto> GetRange(int start, int count)
        {
            return this.GetProductsQuery().Skip(start).Take(count).ProjectTo<ProductDto>(this.mapper.ConfigurationProvider);
        }

        public IEnumerable<ProductInfoDto> GetRangeInfo(int start, int count)
        {
            var products = this.GetProductsQuery().Skip(start).Take(count).ToList();

            var result = new List<ProductInfoDto>();
            foreach (var product in products)
            {
                result.Add(new ProductInfoDto(product));
            }

            return result;
        }

        public IEnumerable<ProductDto> GetRange(int start, int count, bool isAvailable)
        {
            return this.GetProductsQuery().Where(p => p.IsAvailable == isAvailable).Skip(start).Take(count).ProjectTo<ProductDto>(this.mapper.ConfigurationProvider);
        }

        public IEnumerable<ProductDto> GetFiltered(string type = null, string category = null, string unit = null)
        {
            var query = this.GetProductsQuery();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(q => q.Type.Code.Contains(type) || q.Type.Description.Contains(type));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(q => q.ProductCategories.Any(p => p.Category.Code.Contains(category) || p.Category.Description.Contains(category)));
            }

            if (!string.IsNullOrEmpty(unit))
            {
                query = query.Where(q => q.Unit.Code.Contains(unit) || q.Unit.Description.Contains(unit));
            }

            return query.ProjectTo<ProductDto>(this.mapper.ConfigurationProvider);
        }

        private IQueryable<Product> GetProductsQuery()
        {
            return ((StoreDbContext)this.context).Products
                .AsQueryable()
                .Include(e => e.Type)
                .Include(e => e.Unit)
                .Include(e => e.ProductCategories)
                .ThenInclude(e => e.Category);
        }
    }
}
