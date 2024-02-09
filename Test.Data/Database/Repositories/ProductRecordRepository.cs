using Test.Data.Database.Entities;
using Test.Data.Database.Interfaces;

namespace Test.Data.Database.Repositories;

public class ProductRecordRepository(DatabaseContext context)
    : Repository<ProductRecordEntity>(context), IProductRecordRepository
{ }
