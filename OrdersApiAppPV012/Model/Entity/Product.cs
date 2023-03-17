namespace OrdersApiAppPV012.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }   
        public string Name { get; set; }
        public int Article { get; set; }
        public float Price { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }

        public Product()
        {
            Name = " ";
        }



    }
}
