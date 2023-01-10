using Shop.Application.ViewModels;
using Shop.Domain.Models;

namespace Shop.Application.Interfaces;

public interface IProductsRepository
{
    public Task<Product> GetProduct(int id);
    public Task<List<Product>> GetProducts();
    public Task CreateProduct(ProductsViewModel entity);
}