namespace Shop.Domain.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ICollection<Stock> Stock { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}