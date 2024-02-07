using System.ComponentModel.DataAnnotations;

namespace IMPTest.Application.Dto;

public class ProductRecordDto
{
    [Required]
    public int? Id { get; set; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; }

}
