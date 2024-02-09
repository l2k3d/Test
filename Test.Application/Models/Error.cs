using System.Net;

namespace Test.Application.Models;

public sealed record Error(HttpStatusCode Code, string Description)
{
    public static readonly Error None = new(HttpStatusCode.InternalServerError, string.Empty);
    public static readonly Error NotFound = new(HttpStatusCode.NotFound, ErrorMessages.NotFound);
    public static readonly Error Invalid = new(HttpStatusCode.BadRequest, ErrorMessages.Invalid);
    public static readonly Error NoRecordsFound = new(HttpStatusCode.BadRequest, ErrorMessages.NoRecordsFound);
    public static readonly Error MappingFailed = new(HttpStatusCode.BadRequest, ErrorMessages.MappingFailed);
    public static readonly Error NotPositiveQuantity = new(HttpStatusCode.BadRequest, ErrorMessages.NotPositiveQuantity);
    public static readonly Error QuantityIsTooHigh = new(HttpStatusCode.BadRequest, ErrorMessages.QuantityIsTooHigh);
    public static readonly Error QuantityIsTooLow = new(HttpStatusCode.BadRequest, ErrorMessages.QuantityIsTooLow);


}
