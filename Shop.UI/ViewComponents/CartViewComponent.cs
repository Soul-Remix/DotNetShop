using Shop.Application.Services;

namespace Shop.UI.ViewComponents;

public class CartViewComponent : ViewComponent
{
    private readonly CartService _cartService;

    public CartViewComponent(CartService cartService)
    {
        _cartService = cartService;
    }

    public IViewComponentResult Invoke(string view = "Default")
    {
        return View(view, _cartService.GetCart());
    }
}