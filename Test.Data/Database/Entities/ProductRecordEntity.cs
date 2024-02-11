using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Database.Entities;

[Table("Products")]
public class ProductRecordEntity : Entity<ProductRecordEntity>
{
    public int Quantity { get; set; }

    public virtual CapacityRecordEntity? Capacity { get; set; }
}
