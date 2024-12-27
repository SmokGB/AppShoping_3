
using AppShoping.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppShoping.Data;

    public class ShopAppDbContext : DbContext
    {
    
  public ShopAppDbContext(DbContextOptions<ShopAppDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods => Set<Food>();
        public DbSet<BioFood> BioFoods => Set<BioFood>();
        public DbSet<PurchaseStatistics> PurchasesStatistics => Set<PurchaseStatistics>();

        
    }

