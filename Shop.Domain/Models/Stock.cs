namespace Shop.Domain.Models;

public class Stock : BaseEntity
{
    public int Qty { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}