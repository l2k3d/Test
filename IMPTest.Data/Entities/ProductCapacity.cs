using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMPTest.Data.Entities;

public class ProductCapacity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [Range(0,999)]
    public int Capacity { get; set; }

    public required Product Product { get; set; }
}
