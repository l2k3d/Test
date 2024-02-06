using System.ComponentModel.DataAnnotations;

namespace IMPTest.Common.Models;

public class ProductRecord
{
    [Required]
    public int? Id { get; set; }

    [Required]
    [Range(1, 1000)]
    public int? Quantity { get; set; }

}
