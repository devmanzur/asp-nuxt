namespace SimpleCart.Core.Dtos;

public class CartDto
{
    public string ReferenceId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    public decimal Total => Items.Any() ? Items.Select(x => x.TotalPrice).Sum() : 0;
    public decimal Vat => Total * (decimal)0.15;
    public decimal DeliveryCharge => 50;
    public decimal Discount => Total * (decimal)-0.05;
    public decimal Payable => Total + Vat + DeliveryCharge + Discount;
}