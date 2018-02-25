using System.Collections.Generic;

namespace SIENN.DbAccess.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();
    }
}