using Shop.Application.Interfaces;
using Shop.Application.ViewModels;

namespace Shop.UI.Controllers;

[Route("[Controller]/products")]
public class AdminController : Controller
{
    private readonly IAdminProductsRepository _adminRepo;

    public AdminController(IAdminProductsRepository adminRepo)
    {
        _adminRepo = adminRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _adminRepo.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _adminRepo.GetProduct(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductsViewModel entity)
    {
        await _adminRepo.CreateProduct(entity);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductsViewModelAdmin entity)
    {
        await _adminRepo.UpdateProduct(id, entity);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _adminRepo.DeleteProduct(id);
        return NoContent();
    }
}