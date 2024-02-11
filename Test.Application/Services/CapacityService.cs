using AutoMapper;
using Test.Application.Dto;
using Test.Application.Interfaces;
using Test.Application.Models;
using Test.Data.Database.Entities;
using Test.Data.Database.Interfaces;

namespace Test.Application.Services;

public class CapacityService(ICapacityRecordRepository repository, IMapper mapper, IProductService productService) 
    : BaseService<CapacityRecordEntity, CapacityRecordDto>(repository, mapper), ICapacityService
{
    private readonly IProductService _productService = productService;
    public async Task<Result<CapacityRecordDto>> SetProductCapacityAsync(CapacityRecordDto capacityRecordDto)
    {
        var result = await _productService.GetByIdAsync(capacityRecordDto.ProductId);

        if (result.IsFailure || result.Value == null)
            return Result.Failure<CapacityRecordDto>(Error.Invalid);

        var productEntity = result.Value;

        if (productEntity.Quantity > capacityRecordDto.Quantity)
            return Result.Failure<CapacityRecordDto>(Error.QuantityIsTooHigh);

        var capacityEntity = _mapper.Map<CapacityRecordEntity>(capacityRecordDto);

        return await AddAsync(capacityRecordDto);
    }

}