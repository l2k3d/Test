using IMPTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMPTest.Data;

public class WarehouseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Warehouse");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCapacity> ProductCapacities { get; set; }
}
