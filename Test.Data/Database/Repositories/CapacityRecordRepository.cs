using Test.Data.Database.Entities;
using Test.Data.Database.Interfaces;

namespace Test.Data.Database.Repositories;

public class CapacityRecordRepository(DatabaseContext context)
    : Repository<CapacityRecordEntity>(context), ICapacityRecordRepository
{ }
