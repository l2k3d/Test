using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Database.Entities;

[Table("Products")]
public class ProductRecordEntity : Entity<ProductRecordEntity>
{
    public int Quantity { get; set; }

    [ForeignKey("CapacityRecord")]
    public int CapacityId { get; set; }
    public virtual required CapacityRecordEntity Capacity { get; set; }
}
