using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.OrderProductService
{
    public interface IDaoOrderProduct
    {

        Task<List<OrderProduct>> GetAllOrderProducts();
        Task<OrderProduct> GetOrderProductById(int id);
        Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct);
        Task<OrderProduct> UpdateOrderProduct(OrderProduct orderProduct);
        Task<bool> DeleteOrderProduct(int id);

    }
}
