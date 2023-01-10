using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductsViewModel> GetProduct(int id)
    {
        var product = await _context.Products.AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => ProductToView(p))
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