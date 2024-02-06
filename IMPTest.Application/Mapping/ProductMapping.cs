using AutoMapper;
using IMPTest.Common.Models;
using IMPTest.Data.Entities;

namespace IMPTest.Application.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<ProductRecord, Product>();
    }
}
