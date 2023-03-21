using System.Text.Json.Serialization;

namespace OrdersApiAppPV012.Model.Entity
{
    public class OrderProduct
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public int Count { get; set; }

        public OrderProduct()
        {
            Count = 0;
        }

        public OrderProduct(int id, int productId, Product product, int orderId, Order order)
        {
            Id = id;
            ProductId = productId;
            Product = product;
            OrderId = orderId;
            Order = order;
        }
        public override string ToString()
        {
            return $"{Id} - {ProductId} - {OrderId} - {Count}";
        }

    }
}
