using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models;

public class Order : BaseEntity
{
    [Required] public string OrderRef { get; set; }
    [Required] public string FIrstName { get; set; }
    [Required] public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required] public string Address1 { get; set; }
    public string Address2 { get; set; }
    [Required] public string City { get; set; }
    [Required] public string PostCode { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}