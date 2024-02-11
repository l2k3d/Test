using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Database.Entities;

[Table("CapacityRecord")]
public class CapacityRecordEntity : Entity<CapacityRecordEntity>
{
    [ForeignKey("Products")]
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    // Define navigation property to ProductRecordEntity if needed
    public virtual ProductRecordEntity? Products { get; set; }
}
