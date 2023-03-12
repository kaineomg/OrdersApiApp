using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.ProductService
{
    public interface IDaoProduct
    {

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
