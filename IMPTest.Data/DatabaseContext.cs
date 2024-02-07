using IMPTest.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMPTest.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<ProductRecordEntity> Product { get; set; }
    public DbSet<CapacityRecordEntity> Capacity { get; set; }
}
