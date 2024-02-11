using Test.Application.Dto;
using Test.Application.Interfaces;
using Test.Application.Models;
using Test.Data.Database.Interfaces;
using Test.Data.Database.Entities;
using AutoMapper;


namespace Test.Application.Services;

public class ProductService(IProductRecordRepository productRecordRepository, IMapper mapper) 
    : BaseService<ProductRecordEntity, ProductRecordDto>(productRecordRepository, mapper), IProductService
{
    private readonly IProductRecordRepository _productRecordRepository = productRecordRepository;

    public async Task<Result<ProductRecordDto>> DispatchProductAsync(ProductRecordDto productRecordDto)
    {

        var productEntity = await _productRecordRepository.GetByIdWithCapacityAsync(productRecordDto.Id);

        if (productEntity == null)
            return Result.Failure<ProductRecordDto>(Error.NotFound);

        if (productEntity.Capacity == null)
            return Result.Failure<ProductRecordDto>(Error.NotFound);

        productEntity.Quantity -= productRecordDto.Quantity;

        if (productEntity.Quantity < 0)
            return Result.Failure<ProductRecordDto>(Error.QuantityIsTooLow);

        return await UpdateAsync(productEntity);
    }

    public async Task<Result<IEnumerable<ProductRecordDto>>> GetAllProductsAsync(int? id)
        => await GetAllAsync(p => (id == null || p.Id == id) && p.Quantity > 0);

    public async Task<Result<ProductRecordDto>> ReceiveProductAsync(ProductRecordDto productRecordDto)
    {

        var productEntity = await _productRecordRepository.GetByIdWithCapacityAsync(productRecordDto.Id);

        if (productEntity == null)
            return Result.Failure<ProductRecordDto>(Error.NotFound);

        if (productEntity.Capacity == null)
            return Result.Failure<ProductRecordDto>(Error.NotFound);

        productEntity.Quantity += productRecordDto.Quantity;
        if (productEntity.Quantity > productEntity.Capacity.Quantity)
            return Result.Failure<ProductRecordDto>(Error.QuantityIsTooHigh);

        return await UpdateAsync(productEntity);
    }



}