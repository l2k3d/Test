using AutoMapper;
using Test.Api.Models.RequestModels;
using Test.Application.Dto;

namespace Test.Api.Configuration;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<AddProductRequestModel, ProductRecordDto>()
            .ReverseMap();

        CreateMap<ReceiveProductRequestModel, ProductRecordDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ReverseMap();

        CreateMap<DispatchProductRequestModel, ProductRecordDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ReverseMap();


        CreateMap<AddCapacityRequestModel, CapacityRecordDto>().ReverseMap();
    }
}
