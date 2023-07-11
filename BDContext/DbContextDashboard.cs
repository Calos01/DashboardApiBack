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
    }
}
