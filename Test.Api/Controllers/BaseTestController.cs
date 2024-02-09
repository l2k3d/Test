using Test.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Test.Api.Models;

namespace Test.Controllers;

[ApiController]
public class BaseTestController<TDto>(IMapper mapper) : ControllerBase where TDto : BaseDto
{
    private readonly IMapper _mapper = mapper;

    protected TDto MapToDto<TRequestModel>(TRequestModel model) where TRequestModel : BaseRequestModel
    => _mapper.Map<TDto>(model);
}
