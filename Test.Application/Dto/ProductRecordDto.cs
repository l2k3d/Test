using System.ComponentModel.DataAnnotations;

namespace Test.Application.Dto;

public class ProductRecordDto : BaseDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

}
