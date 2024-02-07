using System.ComponentModel.DataAnnotations;

namespace IMPTest.Application.Dto;

public class CapacityRecordDto
{
    [Required]
    public int? ProductId { get; set; }

    [Required]
    [Range(1, 999)]
    public int? Quantity { get; set; }
}
