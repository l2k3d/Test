using System.ComponentModel.DataAnnotations.Schema;

namespace IMPTest.Common.Entities;

[Table("CapacityRecord")]
public class CapacityRecordEntity : BaseEntity<CapacityRecordEntity>
{
    public int Quantity { get; set; }
}
