using System.ComponentModel.DataAnnotations;

namespace Test.Application.Dto;

public class CapacityRecordDto : BaseDto
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
