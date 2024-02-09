using AutoMapper;
using Test.Api.Models.RequestModels;
using Test.Application.Dto;

namespace Test.Api.Configuration;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<AddProductRequestModel, ProductRecordDto>().ReverseMap();
        CreateMap<ReceiveProductRequestModel, ProductRecordDto>().ReverseMap();
        CreateMap<DispatchProductRequestModel, ProductRecordDto>().ReverseMap();
        CreateMap<AddProductRequestModel, ProductRecordDto>().ReverseMap();
        CreateMap<DispatchProductRequestModel, ProductRecordDto>().ReverseMap();


        CreateMap<AddCapacityRequestModel, CapacityRecordDto>().ReverseMap();
    }
}
