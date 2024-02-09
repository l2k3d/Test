using System.ComponentModel.DataAnnotations;

namespace Test.Api.Models.RequestModels;

public class AddCapacityRequestModel : BaseRequestModel
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
