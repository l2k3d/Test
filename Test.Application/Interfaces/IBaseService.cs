using Test.Application.Dto;
using Test.Application.Models;
using System.Linq.Expressions;
using Test.Data.Database.Entities;

namespace Test.Application.Interfaces;

public interface IBaseService<TEntity, TDto> where TEntity : Entity<TEntity> where TDto : BaseDto
{
    Task<Result<TEntity>> GetByIdAsync(int id);
    Task<Result<TDto>> CreateAsync(TEntity entity);
    Task<Result<IEnumerable<TDto>>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
    Task<Result<TDto>> UpdateAsync(TEntity entity);
    Task<Result<TDto>> DeleteAsync(TEntity entity);
    Task<Result<TDto>> AddAsync(TDto dto);
}