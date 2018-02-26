using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.DTO
{
    public class ProductDto : BaseDto
    {
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string UnitCode { get; set; }

        public string UnitDescription { get; set; }

        public string TypeCode { get; set; }

        public string TypeDescription { get; set; }

        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}