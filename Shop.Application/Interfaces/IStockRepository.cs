namespace Shop.Application.Interfaces;

public interface IStockRepository
{
    public Task<StockViewModel> GetStock(int id);
    public Task<List<StockViewModel>> GetStocks();
    public Task<StockViewModel> CreateStock(StockDto entity);
    public Task UpdateStock(int id, StockViewModel entity);
    public Task DeleteStock(int id);
}