using Microsoft.EntityFrameworkCore;

using PointOfSale.EntityFramework.RyanW84;

namespace PointOfSale.EntityFramework.EntityFramework;

internal class ProductsContext: DbContext
    {
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = products.db");
    }

