using System.ComponentModel.DataAnnotations;

namespace Test.Api.Models.RequestModels;

public class ReceiveProductRequestModel : BaseRequestModel
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
