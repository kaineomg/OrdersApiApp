﻿using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Service.ClientService
{
    // Имплементация-заглушка 
    public class PlugDaoClient : IDaoClient
    {
        public static List<Client> clients= new List<Client>(); // иммитация хранилища

        public Task<Client> AddClient(Client client)
        {
            client.Id = clients.Count;
            clients.Add(client);
            return Task.Run(() => client);  // костыль для асинхронности
        }

        public Task<bool> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAllClients()
        {
            return Task.Run(() => clients);
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
