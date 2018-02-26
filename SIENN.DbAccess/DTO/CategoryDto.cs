using System.Collections.Generic;

namespace SIENN.DbAccess.DTO
{
    public class CategoryDto : BaseDto
    {
        public ICollection<ProductDto> Products { get; } = new List<ProductDto>();
    }
}