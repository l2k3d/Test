using System.ComponentModel.DataAnnotations;

namespace Test.Application.Dto;

public class CapacityRecordDto : BaseDto
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
