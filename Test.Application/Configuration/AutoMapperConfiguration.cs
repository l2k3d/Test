using AutoMapper;
using Test.Application.Dto;
using Test.Data.Database.Entities;

namespace Test.Application.Configuration;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<ProductRecordDto, ProductRecordEntity>()
            .ReverseMap();
        CreateMap<CapacityRecordDto, CapacityRecordEntity>()
            .ReverseMap();
    }
}
