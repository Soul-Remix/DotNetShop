namespace Shop.Application.Services;

public interface ICartService
{
    public IEnumerable<CartProduct> GetCart();
    public void AddToCart(CartProduct cp);
}