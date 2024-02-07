using System.ComponentModel.DataAnnotations.Schema;

namespace IMPTest.Common.Entities;

[Table("Products")]
public class ProductRecordEntity : BaseEntity<ProductRecordEntity>
{
    public int Quantity { get; set; }

    [ForeignKey("CapacityRecord")]
    public int CapacityId { get; set; }
    public virtual required CapacityRecordEntity Capacity { get; set; }
}
