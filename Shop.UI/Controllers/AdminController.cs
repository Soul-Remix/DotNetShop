using Shop.Application.Dto;
using Shop.Application.Interfaces;
using Shop.Application.ViewModels;

namespace Shop.UI.Controllers;

[Route("[Controller]/")]
public class AdminController : Controller
{
    private readonly IAdminProductsRepository _productsRepo;
    private readonly IStockRepository _stockRepo;

    public AdminController(IAdminProductsRepository productsRepo, IStockRepository stockRepo)
    {
        _productsRepo = productsRepo;
        _stockRepo = stockRepo;
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productsRepo.GetProducts();
        return Ok(products);
    }

    [HttpGet("products/{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productsRepo.GetProduct(id);
        return Ok(product);
    }

    [HttpPost("products")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductsViewModel entity)
    {
        var p = await _productsRepo.CreateProduct(entity);
        return Ok(p);
    }

    [HttpPut("products/{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductsViewModelAdmin entity)
    {
        await _productsRepo.UpdateProduct(id, entity);
        return Ok();
    }

    [HttpDelete("products/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productsRepo.DeleteProduct(id);
        return NoContent();
    }

    // Stocks

    [HttpGet("stocks")]
    public async Task<IActionResult> GetStock()
    {
        var products = await _stockRepo.GetStocks();
        return Ok(products);
    }

    [HttpPost("stocks")]
    public async Task<IActionResult> CreateStock([FromBody] StockDto entity)
    {
        var p = await _stockRepo.CreateStock(entity);
        return Ok(p);
    }

    [HttpPut("stocks/{id:int}")]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] StockViewModel entity)
    {
        await _stockRepo.UpdateStock(id, entity);
        return Ok();
    }

    [HttpDelete("stocks/{id:int}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        await _stockRepo.DeleteStock(id);
        return NoContent();
    }
}