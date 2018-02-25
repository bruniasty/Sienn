using System.Collections.Generic;

namespace SIENN.Services.DTO
{
    public class CategoryDto : BaseDto
    {
        public ICollection<ProductDto> Products { get; } = new List<ProductDto>();
    }
}