using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.OrderService
{
    public interface IDaoOrder : IDao<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetFullOrderById(int id);
    }


}
