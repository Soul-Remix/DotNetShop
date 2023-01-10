using Shop.Application.Interfaces;
using Shop.Application.ViewModels;

namespace Shop.UI.Pages;

public class IndexModel : PageModel
{
    private readonly IProductsRepository _repository;

    [BindProperty] public ProductsViewModel Product { get; set; } = new ();

    public IndexModel(IProductsRepository repository)
    {
        _repository = repository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        await _repository.CreateProduct(Product);
        return RedirectToPage(nameof(OnGet));
    }
}