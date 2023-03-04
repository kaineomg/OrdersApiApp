using OrdersApiAppPV012.Model.Entity;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Service.OrderService;
using Microsoft.EntityFrameworkCore;

namespace OrdersApiAppPV012.Service.OrderService
{
    public class DbDaoOrder:IDaoOrder
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoOrder(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Order> AddOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            db.SaveChanges();
            return order;
        }

        public Task<bool> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        // получение всех клиентов
        public async Task<List<Order>> GetAllOrders()
        {
            db.Orders.Load();
            return await db.Orders.ToListAsync();
        }

        public Task<Client> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateOrder(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        Task<Order> IDaoOrder.AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        Task<Order> IDaoOrder.GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }


}

