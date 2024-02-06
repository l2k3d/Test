using IMPTest.Common.Models;

namespace IMPTest.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductRecord>> GetProductsAsync();
    Task<bool> SetProductCapacityAsync(CapacityRecord capacity);
    Task<bool> RecieveProductAsync(ProductRecord productRecord);
    Task<bool> DispatchProductAsync(ProductRecord productRecord);
}
