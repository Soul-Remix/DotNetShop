using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Application.ViewModels;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task CreateProduct(ProductsViewModel entity)
    {
        var product = new Product()
        {
            Name = entity.Name,
            Description = entity.Name,
            Price = entity.Price
        };
        _context.Add(product);
        await _context.SaveChangesAsync();
    }
}