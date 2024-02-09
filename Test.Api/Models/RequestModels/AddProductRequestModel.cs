using System.ComponentModel.DataAnnotations;
using Test.Api.Validation;

namespace Test.Api.Models.RequestModels;

public class AddProductRequestModel : BaseRequestModel
{
    [Required(ErrorMessage = "Must Include Name")]
    public string Name { get; set; }

    [Required]
    [NotPositiveQuantity]
    public int Quantity { get; set; }

}
