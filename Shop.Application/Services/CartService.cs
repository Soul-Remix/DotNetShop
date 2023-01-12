using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Services;

public class CartService : ICartService
{
    private readonly ISession _session;

    public CartService(ISession session)
    {
        _session = session;
    }

    public IEnumerable<CartProduct> GetCart()
    {
        _session.TryGetValue("Cart", out byte[] cart);

        return JsonSerializer.Deserialize<IEnumerable<CartProduct>>(cart) ?? Array.Empty<CartProduct>();
    }

    public void AddToCart(CartProduct cp)
    {
        _session.TryGetValue("Cart", out byte[] oldCart);

        var cart = JsonSerializer.Deserialize<List<CartProduct>>(oldCart) ?? new List<CartProduct>();

        if (cart.Any(c => c.StockId == cp.StockId))
        {
            cart.Find(c => c.StockId == cp.StockId)!.Qty += cp.Qty;
        }
        else
        {
            cart.Add(cp);
        }

        var cpString = JsonSerializer.SerializeToUtf8Bytes(cart);
        _session.Set("Cart", cpString);
    }
}