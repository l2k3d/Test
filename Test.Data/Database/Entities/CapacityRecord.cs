using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Database.Entities;

[Table("CapacityRecord")]
public class CapacityRecordEntity : Entity<CapacityRecordEntity>
{
    public int Quantity { get; set; }
}
