using IMPTest.Common.Models;
using IMPTest.Data.Entities;
using IMPTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMPTest.Data.Repositories;

public class ProductRepository(WarehouseContext context) : IProductRepository
{
    private readonly WarehouseContext _context = context;

    public async Task<int> Create(Product entity)
    {
        var product = await _context.Products.AddAsync(entity);
        return await _context.SaveChangesAsync(true);
    }

    public async Task<int> Delete(Product entity)
    {
        var product = await _context.Products.SingleAsync(p => p.Id == entity.Id);
        _context.Products.Remove(product);
        return await _context.SaveChangesAsync(true);
    }

    public Task<List<Product>> GetAll() => _context.Products.ToListAsync();

    public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);

    public async Task<int> Update(Product entity)
    {
        var product = await _context.Products.SingleAsync(p => p.Id == entity.Id);
        product.Quantity = entity.Quantity;
        return await _context.SaveChangesAsync(true);
    }
}
