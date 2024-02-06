using IMPTest.Application.Interfaces;
using IMPTest.Common.Models;
using IMPTest.Data.Interfaces;

namespace IMPTest.Application;

public class ProductService(IProductRepository productRepository,IProductCapacityRepository productCapacityRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IProductCapacityRepository _productCapacityRepository = productCapacityRepository;

    public async Task<bool> DispatchProductAsync(ProductRecord productRecord)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductRecord>> GetProductsAsync()
    {
        //todo: Implement Mapping
        throw new NotImplementedException();
       // return await _productRepository.GetAll();
    }

    public async Task<bool> RecieveProductAsync(ProductRecord productRecord)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SetProductCapacityAsync(CapacityRecord capacity)
    {
        throw new NotImplementedException();
    }
}
