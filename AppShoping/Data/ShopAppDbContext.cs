
using AppShoping.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppShoping.Data
{
    public class ShopAppDbContext : DbContext
    {
        public DbSet<Food> Foods => Set<Food>();
        public DbSet<BioFood> BioFoods => Set<BioFood>();
        public DbSet<PurchaseStatistics> PurchasesStatistics => Set<PurchaseStatistics>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
