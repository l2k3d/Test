using IMPTest.Data.Entities;
using IMPTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMPTest.Data.Repositories;

public class ProductCapacityRepository(WarehouseContext context) : IProductCapacityRepository
{
    private readonly WarehouseContext _context = context;

    public async Task<int> Create(ProductCapacity entity)
    {
        var product = await _context.ProductCapacities.AddAsync(entity);
        return await _context.SaveChangesAsync(true);
    }

    public async Task<int> Delete(ProductCapacity entity)
    {
        var productCapacity = await _context.ProductCapacities.SingleAsync(p => p.Id == entity.Id);
        _context.ProductCapacities.Remove(productCapacity);
        return await _context.SaveChangesAsync(true);
    }

    public Task<List<ProductCapacity>> GetAll() => _context.ProductCapacities.ToListAsync();

    public async Task<ProductCapacity> GetById(int id) => await _context.ProductCapacities.FindAsync(id);

    public async Task<int> Update(ProductCapacity entity)
    {
        var product = await _context.ProductCapacities.SingleAsync(p => p.Id == entity.Id);
        product.Capacity = entity.Capacity;
        return await _context.SaveChangesAsync(true);
    }
}
