using System.Net;

namespace Test.Application.Models;

public sealed record Error(HttpStatusCode Code, string Description)
{
    public static readonly Error None = new(HttpStatusCode.InternalServerError, string.Empty);
    public static readonly Error NotFound = new(HttpStatusCode.NotFound, "Not Found");
    public static readonly Error Invalid = new(HttpStatusCode.BadRequest, "Not Found");
    public static readonly Error NoRecordsFound = new(HttpStatusCode.BadRequest, "No Records were found");
    public static readonly Error MappingFailed = new(HttpStatusCode.BadRequest, "Failed to map dto to entity");
    public static readonly Error NotPositiveQuantity = new(HttpStatusCode.BadRequest, "Not a positive Quantity");
    public static readonly Error QuantityIsTooHigh = new(HttpStatusCode.BadRequest, "Quantity is too high");
    public static readonly Error QuantityIsTooLow = new(HttpStatusCode.BadRequest, "Quantity is too low");


}
