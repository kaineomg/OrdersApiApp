using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.ClientService
{
    // имплементация dao, работающая с БД
    public class DbDaoClient : IDao<Client>
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoClient(ApplicationDbContext db)
        {
            
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Client> Add(Client client)
        {
            await db.Clients.AddAsync(client);
            db.SaveChanges();
            return client;
           
        }

        public async Task<bool> Delete(int id)
        {
            Client client = await db.Clients.FirstOrDefaultAsync(p => p.Id == id);

            if(client!=null)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // получение всех клиентов
        public async Task<List<Client>> GetAll()
        {
            db.Clients.Load();
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            
            return await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
         
        }

        public async Task<Client> Update(Client client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
            return client;
        }
    }
}
