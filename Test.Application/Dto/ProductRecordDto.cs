namespace Test.Application.Dto;

public class ProductRecordDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public CapacityRecordDto? Capacity { get; set; }

}
