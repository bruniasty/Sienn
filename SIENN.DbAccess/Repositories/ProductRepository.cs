using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository<T, TKey> : StoreRepository<T, TKey>
        where T : Product
        where TKey : IEquatable<TKey>
    {
        public ProductRepository(StoreDbContext context) : base(context)
        {
        }

        public override T Get(int id)
        {
            return (T)this.GetProductsQuery().FirstOrDefault(e => e.Id == id);
        }

        public override IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)this.GetProductsQuery().ToList();
        }

        public override IEnumerable<T> GetRange(int start, int count)
        {
            return (IEnumerable<T>)this.GetProductsQuery().Skip(start).Take(count);
        }

        public IEnumerable<T> GetRange(int start, int count, bool isAvailable)
        {
            return (IEnumerable<T>)this.GetProductsQuery().Where(p => p.IsAvailable == isAvailable).Skip(start).Take(count);
        }

        public IEnumerable<T> GetFiltered(string type = null, string category = null, string unit = null)
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

            return (IEnumerable<T>)query;
        }

        private IQueryable<Product> GetProductsQuery()
        {
            return ((StoreDbContext)this.context).Products
                .Include(e => e.Type)
                .Include(e => e.Unit)
                .Include(e => e.ProductCategories)
                .ThenInclude(e => e.Category)
                .AsQueryable();
        }
    }
}
