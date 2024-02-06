using AutoMapper;
using IMPTest.Common.Models;
using IMPTest.Data.Entities;

namespace IMPTest.Application.Mapping;

public class ProductCapacityMapping : Profile
{
    public ProductCapacityMapping()
    {
        CreateMap<CapacityRecord, ProductCapacity>();
    }
}
