using Shop.Application.Interfaces;
using Shop.Application.ViewModels;

namespace Shop.UI.Pages;

public class IndexModel : PageModel
{
    private readonly IProductsRepository _repository;

    [BindProperty] public ProductsViewModel Product { get; set; } = new();
    public IEnumerable<ProductsViewModel> Products { get; set; }

    public IndexModel(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async Task OnGet()
    {
        Products = await _repository.GetProducts();
    }

    public async Task<IActionResult> OnPost()
    {
        return RedirectToPage(nameof(OnGet));
    }
}