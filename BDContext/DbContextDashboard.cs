using DashboardApiBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApiBack.BDContext
{
    public class DbContextDashboard:DbContext
    {
        public DbContextDashboard(DbContextOptions<DbContextDashboard> options) : base(options)
        {
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, Name = "Chacalon", Email = "Junior@HOTMAIL.COM" },
                    new Customer { Id = 2, Name = "Chapita", Email = "Scalante@HOTMAIL.COM" },
                    new Customer { Id = 3, Name = "Jorsh", Email = "Bush@HOTMAIL.COM" },
                    new Customer { Id = 4, Name = "Chicarita", Email = "Lissent@HOTMAIL.COM" }
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
