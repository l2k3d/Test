using Test.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<ProductRecordEntity> Product { get; set; }
    public DbSet<CapacityRecordEntity> Capacity { get; set; }
}
