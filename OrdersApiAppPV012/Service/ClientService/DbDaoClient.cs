using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model;
using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.ClientService
{
    // имплементация dao, работающая с БД
    public class DbDaoClient : IDaoClient
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoClient(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Client> AddClient(Client client)
        {
            await db.Clients.AddAsync(client);
            db.SaveChanges();
            return client;
        }

        public Task<bool> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        // получение всех клиентов
        public async Task<List<Client>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
