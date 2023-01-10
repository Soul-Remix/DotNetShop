namespace Shop.Application.Interfaces;

public interface IAdminProductsRepository
{
    public Task<ProductsViewModelAdmin> GetProduct(int id);
    public Task<List<ProductsViewModelAdmin>> GetProducts();
    public Task CreateProduct(ProductsViewModel entity);
    public Task UpdateProduct(int id, ProductsViewModelAdmin entity);
    public Task DeleteProduct(int id);
}