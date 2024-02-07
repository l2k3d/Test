using AutoMapper;
using IMPTest.Application.Dto;
using IMPTest.Common.Entities;

namespace IMPTest.Application.Configuration;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<ProductRecordDto, ProductRecordEntity>().ReverseMap();
        CreateMap<CapacityRecordDto, CapacityRecordEntity>().ReverseMap();
    }
}
