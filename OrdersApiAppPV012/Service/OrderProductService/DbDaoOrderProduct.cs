using OrdersApiAppPV012.Model.Entity;
using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Service.OrderProductService;

namespace OrdersApiAppPV012.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDao<OrderProduct>
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }




        public async Task<OrderProduct> Add(OrderProduct orderProduct)
        {
            await db.OrderProducts.AddAsync(orderProduct);
            db.SaveChanges();
            return orderProduct;
        }

        public async Task<bool> Delete(int id)
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

        public async Task<List<OrderProduct>> GetAll()
        {
            db.OrderProducts.Load();
            return await db.OrderProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetById(int id)
        {
            return await db.OrderProducts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<OrderProduct> Update(OrderProduct orderProduct)
        {
            db.OrderProducts.Update(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }
    }
}
