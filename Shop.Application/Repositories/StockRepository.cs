using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Repositories;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StockViewModel> GetStock(int id)
    {
        var stock = await _context.Stocks.AsNoTracking()
            .Where(p => p.ProductId == id)
            .Select(s => StockToView(s))
            .FirstOrDefaultAsync();

        return stock;
    }

    public async Task<List<StockViewModel>> GetStocks()
    {
        return await _context.Stocks.AsNoTracking()
            .Select(s => StockToView(s))
            .ToListAsync();
    }

    public async Task<StockViewModel> CreateStock(StockDto entity)
    {
        var stock = new Stock()
        {
            ProductId = entity.ProductId,
            Qty = entity.Qty
        };
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();
        return StockToView(stock);
    }

    public async Task UpdateStock(int id, StockViewModel entity)
    {
        if (id != entity.Id)
        {
            return;
        }

        var stock = await _context.Stocks.FirstOrDefaultAsync(p => p.Id == id);

        if (stock == null)
        {
            return;
        }

        stock.Qty = entity.Qty;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteStock(int id)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        if (stock != null)
        {
            _context.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }

    private static StockViewModel StockToView(Stock s)
    {
        return new StockViewModel()
        {
            Id = s.Id,
            Qty = s.Qty
        };
    }
}