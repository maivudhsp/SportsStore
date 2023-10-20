using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {}
        public DbSet<Product> Products { get; set;}
        //public DbSet<Cart> Carts { get; set;}
    }
}
