namespace Test.Api.Models.RequestModels;

public class DispatchProductRequestModel : BaseRequestModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
