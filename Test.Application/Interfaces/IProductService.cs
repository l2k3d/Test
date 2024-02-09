using Test.Application.Dto;
using Test.Application.Models;
using Test.Data.Database.Entities;

namespace Test.Application.Interfaces;

public interface IProductService : IBaseService<ProductRecordEntity, ProductRecordDto>
{
    Task<Result<ProductRecordDto>> DispatchProductAsync(ProductRecordDto productRecordDto);
    Task<Result<IEnumerable<ProductRecordDto>>> GetAllProductsAsync(int? id);
    Task<Result<ProductRecordDto>> ReceiveProductAsync(ProductRecordDto productRecordDto);
}
