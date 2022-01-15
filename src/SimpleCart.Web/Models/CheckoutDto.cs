using SimpleCart.Core.Dtos;

namespace SimpleCart.Web.Models;

public class CheckoutDto
{
    public List<CartItemDto> Items { get; set; }
    public decimal Total => Items.Any() ? Items.Select(x => x.TotalPrice).Sum() : 0;
    public decimal Vat => Total * (decimal)0.15;
    public decimal DeliveryCharge => 50;
    public decimal Discount => Total * (decimal)-0.05;
    public decimal Payable => Total + Vat + DeliveryCharge + Discount;
    public string ArrivalDate { get; set; }
    public string PaymentType { get; set; }
    public string PaymentStatus { get; set; }
}