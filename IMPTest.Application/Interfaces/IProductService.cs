using IMPTest.Application.Dto;
using IMPTest.Application.Models;

namespace IMPTest.Application.Interfaces;

public interface IProductService
{
    Task<Result<IEnumerable<ProductRecordDto>?>> GetProducts(int? id);
    Task<Result<CapacityRecordDto>> SetProductCapacityAsync(CapacityRecordDto capacity);
    Task<Result<ProductRecordDto>> RecieveProductAsync(ProductRecordDto productRecord);
    Task<Result<ProductRecordDto>> DispatchProductAsync(ProductRecordDto productRecord);
    Task<Result<ProductRecordDto>> AddProduct(ProductRecordDto productDto);
}
