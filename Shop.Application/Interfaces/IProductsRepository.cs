namespace Shop.Application.Interfaces;

public interface IProductsRepository
{
    public Task<Product> GetProduct(string name);
    public Task<List<ProductsViewModel>> GetProducts();
}