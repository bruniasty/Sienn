namespace SIENN.DbAccess.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
        }

        public ProductCategory(Product product, int categoryId)
        {
            this.Product = product;
            this.CategoryId = categoryId;
        }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}