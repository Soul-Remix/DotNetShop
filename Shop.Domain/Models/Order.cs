namespace Shop.Domain.Models;

public class Order : BaseEntity
{
    public string OrderRef { get; set; }

    public string Addres1 { get; set; }
    public string Addres2 { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}