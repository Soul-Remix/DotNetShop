using Shop.Application.Interfaces;

namespace Shop.UI.Pages;

public class Product : PageModel
{
    private readonly IProductsRepository _repository;

    [BindProperty] public Shop.Domain.Models.Product P { get; set; }

    public Product(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet(string name)
    {
        P = await _repository.GetProduct(name);
    }
}