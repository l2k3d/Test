using IMPTest.Common.Entities;
using IMPTest.Data.Interfaces;

namespace IMPTest.Data.Repositories;

public class CapacityRecordRepository(DatabaseContext context) : Repository<CapacityRecordEntity>(context), ICapacityRecordRepository
{
}
