namespace Test.Api.Models.RequestModels;

public class ReceiveProductRequestModel : BaseRequestModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
