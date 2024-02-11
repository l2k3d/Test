using AutoMapper;
using Test.Application.Dto;
using Test.Application.Interfaces;
using Test.Application.Models;
using System.Linq.Expressions;
using Test.Data.Database.Interfaces;
using Test.Data.Database.Entities;

namespace Test.Application.Services;

public abstract class BaseService<TEntity, TDto>
    : IBaseService<TEntity, TDto> where TEntity
    : Entity<TEntity> where TDto : BaseDto
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    protected BaseService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<TEntity>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return entity == null
            ? Result.Failure<TEntity>(Error.NotFound)
            : Result.Success(_mapper.Map<TEntity>(entity));
    }

    public virtual async Task<Result<TDto>> AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        
        return entity == null
            ? Result.Failure<TDto>(Error.MappingFailed)
            : await CreateAsync(entity);
    }
    public virtual async Task<Result<TDto>> CreateAsync(TEntity entity)
    {
        var updatedRowcount = await _repository.CreateAsync(entity);
        
        return updatedRowcount > 0
            ? Result.Success(_mapper.Map<TDto>(entity))
            : Result.Failure<TDto>(Error.None);
    }

    public async Task<Result<IEnumerable<TDto>>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entities = await _repository.GetAsync(expression);
        
        return Result.Success(_mapper.Map<IEnumerable<TDto>>(entities));
    }

    public async virtual Task<Result<TDto>> UpdateAsync(TEntity entity)
    {
        var updatedRowcount = await _repository.UpdateAsync(entity);
        
        return updatedRowcount > 0
            ? Result.Success(_mapper.Map<TDto>(entity))
            : Result.Failure<TDto>(Error.None);
    }

    public async Task<Result<TDto>> DeleteAsync(TEntity entity)
    {
        var updatedRowcount = await _repository.DeleteAsync(entity);
        
        return updatedRowcount > 0
            ? Result.Success<TDto>()
            : Result.Failure<TDto>(Error.None);
    }
}
