using Shop.Application.Interfaces;
using Shop.Application.Services;
using Shop.Domain.Models;

namespace Shop.UI.Pages;

public class Product : PageModel
{
    private readonly IProductsRepository _repository;
    private readonly ICartService _cartService;

    [BindProperty] public Shop.Domain.Models.Product P { get; set; }
    [BindProperty] public CartProduct CartModel { get; set; }

    public Product(IProductsRepository repository, ICartService cartService)
    {
        _repository = repository;
        _cartService = cartService;
    }

    public async Task OnGet(string name)
    {
        P = await _repository.GetProduct(name);
    }

    public void onPost()
    {
        _cartService.AddToCart(CartModel);
    }
}