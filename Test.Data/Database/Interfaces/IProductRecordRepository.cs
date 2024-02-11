using Test.Data.Database.Entities;

namespace Test.Data.Database.Interfaces;

public interface IProductRecordRepository : IRepository<ProductRecordEntity>
{
    Task<ProductRecordEntity?> GetByIdWithCapacityAsync(int id);
}