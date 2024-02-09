using Test.Application.Dto;
using Test.Application.Models;
using Test.Data.Database.Entities;

namespace Test.Application.Interfaces;

public interface ICapacityService : IBaseService<CapacityRecordEntity, CapacityRecordDto>
{
    Task<Result<CapacityRecordDto>> SetProductCapacityAsync(CapacityRecordDto capacity);
}
