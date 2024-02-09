using System.ComponentModel.DataAnnotations;
using Test.Application.Models;

namespace Test.Api.Validation;

public class NotPositiveQuantity : ValidationAttribute
{
    public NotPositiveQuantity() : base(ErrorMessages.NotPositiveQuantity) { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        => (value is int quantity && quantity <= 0)
        ? new ValidationResult(ErrorMessage)
        : ValidationResult.Success;
}