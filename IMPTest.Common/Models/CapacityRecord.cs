using System.ComponentModel.DataAnnotations;

namespace IMPTest.Common.Models;

public class CapacityRecord
{
    [Required]
    public int? ProductId { get; set; }

    [Required]
    [Range(1, 1000)]
    public int? Capacity { get; set; }
}
