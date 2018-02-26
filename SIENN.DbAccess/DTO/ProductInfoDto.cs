using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.DTO
{
    public class ProductInfoDto
    {
        public ProductInfoDto(Product product)
        {
            this.ProductDescription = $"({product.Code}) {product.Description}";
            this.Price = $"{product.Price:N2} zł";
            this.IsAvailable = product.IsAvailable ? "Dostępny" : "Niedostpęny";
            this.DeliveryDate = product.DeliveryDate.ToString("dd.MM.yyyy");
            this.CategoriesCount = product.ProductCategories.Count;
            this.Type = $"({product.Type.Code}) {product.Type.Description}";
            this.Unit = $"({product.Unit.Code}) {product.Unit.Description}";
        }

        public string ProductDescription { get; }

        public string Price { get; }

        public string IsAvailable { get; }

        public string DeliveryDate { get; }

        public int CategoriesCount { get; }

        public string Type { get; }

        public string Unit { get; }
    }
}