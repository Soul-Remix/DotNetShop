using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Repositories;

public class AdminProductsRepository : IAdminProductsRepository
{
    private readonly ApplicationDbContext _context;

    public AdminProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductsViewModelAdmin> GetProduct(int id)
    {
        var product = await _context.Products.AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => ProductToView(p))
            .FirstOrDefaultAsync();

        return product;
    }

    public async Task<List<ProductsViewModelAdmin>> GetProducts()
    {
        return await _context.Products.AsNoTracking()
            .Select(p => ProductToView(p))
            .ToListAsync();
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

    public async Task UpdateProduct(int id, ProductsViewModelAdmin entity)
    {
        if (id != entity.Id)
        {
            return;
        }

        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return;
        }

        product.Name = entity.Name;
        product.Description = entity.Description;
        product.Price = entity.Price;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    private ProductsViewModelAdmin ProductToView(Product p)
    {
        return new ProductsViewModelAdmin()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        };
    }
}