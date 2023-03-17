using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.ProductService
{
    public class DbDaoProduct : IDao<Product>

    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoProduct(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }


        public async Task<Product> Add(Product product)
        {
            await db.Products.AddAsync(product);
            db.SaveChanges();
            return product;
        }

        public async Task<bool> Delete(int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAll()
        {
            db.Products.Load();
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
