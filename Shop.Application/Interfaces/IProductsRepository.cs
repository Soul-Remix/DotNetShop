namespace Shop.Application.Interfaces;

public interface IProductsRepository
{
    public Task<ProductsViewModel> GetProduct(int id);
    public Task<List<ProductsViewModel>> GetProducts();
}