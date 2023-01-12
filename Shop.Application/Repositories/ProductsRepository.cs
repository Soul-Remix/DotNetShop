using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProduct(string name)
    {
        var product = await _context.Products.AsNoTracking()
            .Where(p => p.Name == name)
            .Include(p => p.Stock)
            .FirstOrDefaultAsync();

        return product;
    }

    public async Task<List<ProductsViewModel>> GetProducts()
    {
        return await _context.Products.AsNoTracking()
            .Select(p => ProductToView(p))
            .ToListAsync();
    }

    private static ProductsViewModel ProductToView(Product p)
    {
        return new ProductsViewModel()
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        };
    }
}