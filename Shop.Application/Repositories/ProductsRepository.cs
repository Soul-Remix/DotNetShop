using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Repositories;

public class ProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateProduct(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
    }
}