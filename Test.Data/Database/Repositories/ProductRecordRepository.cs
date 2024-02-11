using Microsoft.EntityFrameworkCore;
using Test.Data.Database.Entities;
using Test.Data.Database.Interfaces;

namespace Test.Data.Database.Repositories;

public class ProductRecordRepository(DatabaseContext context, ICapacityRecordRepository capacityRecordRepository)
    : Repository<ProductRecordEntity>(context), IProductRecordRepository
{
    private readonly ICapacityRecordRepository _capacityRecordRepository = capacityRecordRepository;

    public async Task<ProductRecordEntity?> GetByIdWithCapacityAsync(int id)
    {
        var productRecordEntity = await GetByIdAsync(id);
        
        if (productRecordEntity != null) 
        productRecordEntity.Capacity = (await _capacityRecordRepository.GetAsync(c => c.ProductId == id)).FirstOrDefault();

        return productRecordEntity;

    }

}
