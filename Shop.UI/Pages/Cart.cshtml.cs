using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Services;
using Shop.Domain.Models;

namespace Shop.UI.Pages;

public class Cart : PageModel
{
    private readonly ICartService _cartService;

    public IEnumerable<CartProduct> CartModel { get; set; }

    public Cart(ICartService cartService)
    {
        _cartService = cartService;
    }

    public void OnGet()
    {
        CartModel = _cartService.GetCart();
    }
}