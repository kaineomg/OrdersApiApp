using System.Text.Json.Serialization;

namespace OrdersApiAppPV012.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }   
        public string Name { get; set; }
        public int Article { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public Product()
        {
            Name = "";
        }
        public Product(int id, string? name, int article, int price)
        {
            Id = id;
            Name = name;
            Article = article;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Article} - {Price}";
        }



    }
}
