using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApiAppPV012.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int ClientId { get; set; }

        public Client? Client { get; set; }  

        public ICollection<OrderProduct>? OrderProducts { get; set; }    

        public Order()
        {
            Description = "";
        }

        public Order(int id, string? description, int clientId, Client client)
        {
            Id = id;
            Description = description;
            ClientId = clientId;
            Client = client;
        }

        public override string ToString()
        {
            return $"{Id} - {Description} - {ClientId}";
        }
    }
}
