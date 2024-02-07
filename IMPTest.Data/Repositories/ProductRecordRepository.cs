using IMPTest.Common.Entities;
using IMPTest.Data.Interfaces;

namespace IMPTest.Data.Repositories
{
    public class ProductRecordRepository(DatabaseContext context) : Repository<ProductRecordEntity>(context), IProductRecordRepository
    {
    }
}
