using SimpleCart.Core.Dtos;

namespace SimpleCart.Web.Models;

public class CheckoutDto
{
    public CartDto Cart { get; set; }
    public string ArrivalDate { get; set; }
    public string PaymentType { get; set; }
    public string PaymentStatus { get; set; }
}