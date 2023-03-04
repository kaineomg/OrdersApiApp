using OrdersApiAppPV012.Model.Entity;       

namespace OrdersApiAppPV012.Service.OrderService
{
    public interface IDaoOrder
    {

        
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
