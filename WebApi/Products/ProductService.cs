namespace WebApi.Products
{
    public sealed class ProductService
    {
        public async Task<List<Product>> GetProductsBy()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" }
            };
        }
    }
}
