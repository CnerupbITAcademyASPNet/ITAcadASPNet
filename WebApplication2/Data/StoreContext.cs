using Microsoft.EntityFrameworkCore;

using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
