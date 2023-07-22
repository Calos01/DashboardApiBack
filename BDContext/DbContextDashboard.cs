using DashboardApiBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApiBack.BDContext
{
    public class DbContextDashboard:DbContext
    {
        private Random _random = new Random();
        public DbContextDashboard(DbContextOptions<DbContextDashboard> options) : base(options)
        {
        }
        public List<String> estados = new List<String>() {
            "Junin", "Lima", "Hvca", "Cochas", "Sicaya", "Chupaca"
        };   
        public string getRandom(List<String> est)
        {
            return est[_random.Next(est.Count)];
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, Name = "Chacalon", Email = "Junior@HOTMAIL.COM", State= getRandom(estados) },
                    new Customer { Id = 2, Name = "Chapita", Email = "Scalante@HOTMAIL.COM", State = getRandom(estados) },
                    new Customer { Id = 3, Name = "Jorsh", Email = "Bush@HOTMAIL.COM", State = getRandom(estados) },
                    new Customer { Id = 4, Name = "Chicarita", Email = "Lissent@HOTMAIL.COM", State = getRandom(estados) }
                );
            //modelBuilder.Entity<Pedido>().HasData(
            //        new Pedido { Id = 1, Customer = { Id = 1, Name = "Chacalon", Email = "Junior@HOTMAIL.COM" }, Amount = 100, Status },
                   
            //    );
            modelBuilder.Entity<Server>().HasData(
                   new Server { Id = 1, Name = "La Laland", Online = true},
                   new Server { Id = 2, Name = "Moonlight", Online = true },
                   new Server { Id = 3, Name = "Barry", Online = false }
               );
        }
    }
}
