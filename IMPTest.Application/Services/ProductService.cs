using AutoMapper;
using IMPTest.Application.Dto;
using IMPTest.Application.Interfaces;
using IMPTest.Application.Models;
using IMPTest.Common.Entities;
using IMPTest.Data.Interfaces;

namespace IMPTest.Application.Services;

public class ProductService(IProductRecordRepository productRecordRepository,
    ICapacityRecordRepository capacityRecordRepository,
    IMapper mapper) : IProductService
{
    private readonly IProductRecordRepository _productRecordRepository = productRecordRepository;
    private readonly ICapacityRecordRepository _capacityRecordRepository = capacityRecordRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<IEnumerable<ProductRecordDto>?>> GetProducts(int? id)
    {
        var products = await _productRecordRepository
            .GetAllAsync(p => p.Id == id && p.Quantity > 0);

        return Result<IEnumerable<ProductRecordDto>?>.Success(_mapper.Map<IEnumerable<ProductRecordEntity>, IEnumerable<ProductRecordDto>>(products));
    }

    public async Task<Result<ProductRecordDto>> AddProduct(ProductRecordDto productDto)
    {
        var productRecord = _mapper.Map<ProductRecordDto, ProductRecordEntity>(productDto);

        if (productRecord == null)
            return Result<ProductRecordDto>.Failure(Error.Invalid);

        return await _productRecordRepository.CreateAsync(productRecord) > 0 
            ? Result<ProductRecordDto>.Success() 
            : Result<ProductRecordDto>.Failure(Error.None);
    }

    public async Task<Result<ProductRecordDto>> RecieveProductAsync(ProductRecordDto productDto)
    {
        if(productDto.Id == null)
            return Result<ProductRecordDto>.Failure(Error.Invalid);

        var productRecord = await _productRecordRepository
            .GetByIdAsync(productDto.Id.Value);

        if (productRecord == null)
            return Result<ProductRecordDto>.Failure(Error.Invalid);

        if (productDto.Quantity <= 0)
            return Result<ProductRecordDto>.Failure(Error.NotPositiveQuantity);

        if(productRecord.Quantity + productDto.Quantity > productRecord.Capacity.Quantity)
            return Result<ProductRecordDto>.Failure(Error.QuantityIsTooHigh);

        productRecord.Quantity += productDto.Quantity;

        return await _productRecordRepository.UpdateAsync(productRecord) > 0 
            ? Result<ProductRecordDto>.Success() 
            : Result<ProductRecordDto>.Failure(Error.None);
    }

    public async Task<Result<ProductRecordDto>> DispatchProductAsync(ProductRecordDto productDto)
    {
        var productRecord = _mapper.Map<ProductRecordDto, ProductRecordEntity>(productDto);

        if (productRecord == null)
            return Result<ProductRecordDto>.Failure(Error.Invalid);

        return await _productRecordRepository.UpdateAsync(productRecord) >  0 
            ? Result<ProductRecordDto>.Success() 
            : Result<ProductRecordDto>.Failure(Error.None);
    }
    public async Task<Result<CapacityRecordDto>> SetProductCapacityAsync(CapacityRecordDto capacityRecordDto)
    {
        var capacityRecord = _mapper.Map<CapacityRecordDto, CapacityRecordEntity>(capacityRecordDto);

        if (capacityRecord == null || capacityRecordDto.ProductId == null)
            return Result<CapacityRecordDto>.Failure(Error.Invalid);

        if (capacityRecordDto.Quantity <= 0)
            return Result<CapacityRecordDto>.Failure(Error.NotPositiveQuantity);

        var productRecord = await _productRecordRepository
            .GetByIdAsync(capacityRecordDto.ProductId.Value);

        if (productRecord == null)
            return Result<CapacityRecordDto>.Failure(Error.Invalid);

        if (productRecord.Quantity + capacityRecordDto.Quantity > productRecord.Capacity.Quantity)
            return Result<CapacityRecordDto>.Failure(Error.QuantityIsTooHigh);

        return await _capacityRecordRepository.CreateAsync(capacityRecord) >  0 
            ? Result<CapacityRecordDto>.Success() 
            : Result<CapacityRecordDto>.Failure(Error.None);
    }

}
