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

        // добавление нового ордера
        public async Task<Order> Add(Order order)
        {
           
            await db.Orders.AddAsync(order);
            db.SaveChanges();
            return order;
        }
        //удаление ордера
        public async Task<bool> Delete(int id)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(p => p.Id == id);

            if (order != null)
            {
                db.Orders.Remove(order);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // получение всех ордеров
        public async Task<List<Order>> GetAll()
        {
            db.Orders.Load();
            return await db.Orders.ToListAsync();
        }

      

        // получение ордера по id
        public async Task<Order> GetById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        

        //обновление ордера
        public async Task<Order> Update(Order order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            db.Orders.Load();
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetFullOrderById(int id)
        {
            await db.OrderProducts.LoadAsync();
            await db.Products.LoadAsync();
            return await db.Orders.FirstOrDefaultAsync(or => or.Id == id);
        }




    }


}

