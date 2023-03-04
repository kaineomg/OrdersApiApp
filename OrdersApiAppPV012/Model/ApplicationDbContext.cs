using Microsoft.EntityFrameworkCore;
using OrdersApiAppPV012.Model.Entity;

namespace OrdersApiAppPV012.Model
{
    // класс-контекст БД
    public class ApplicationDbContext : DbContext
    {
        // таблицы
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Client)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.Restrict);
        }


        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
