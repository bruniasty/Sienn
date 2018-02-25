using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIENN.DbAccess.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int TypeId { get; set; }

        [Required]
        public Type Type { get; set; }

        public int UnitId { get; set; }

        [Required]
        public Unit Unit { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}