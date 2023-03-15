using OrdersApiAppPV012.Model.Entity;
using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Service.OrderProductService;

namespace OrdersApiAppPV012.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDaoOrderProduct
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }




        public async Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct)
        {
            await db.OrderProducts.AddAsync(orderProduct);
            db.SaveChanges();
            return orderProduct;
        }

        public async Task<bool> DeleteOrderProduct(int id)
        {
            OrderProduct orderProduct = await db.OrderProducts.FirstOrDefaultAsync(p => p.Id == id);

            if (orderProduct != null)
            {
                db.OrderProducts.Remove(orderProduct);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<OrderProduct>> GetAllOrderProducts()
        {
            db.OrderProducts.Load();
            return await db.OrderProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetOrderProductById(int id)
        {
            return await db.OrderProducts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<OrderProduct> UpdateOrderProduct(OrderProduct orderProduct)
        {
            db.OrderProducts.Update(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }
    }
}
