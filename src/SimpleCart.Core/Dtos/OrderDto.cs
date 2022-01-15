namespace SimpleCart.Core.Dtos;

public class OrderDto
{
    public string TrackingId { get; set; }
    
    public string ArrivalDate { get; set; }
    public string PaymentType { get; set; }
    public string PaymentStatus { get; set; }
    public string OrderStatus { get; set; }
    public decimal PayableAmount { get; set; }
}
public class OrderDetailsDto : OrderDto
{
    public List<OrderItemDto> Items { get; set; }
    public decimal Total => Items.Any() ? Items.Select(x => x.TotalPrice).Sum() : 0;
    public decimal Vat => Total * (decimal)0.15;
    public decimal DeliveryCharge => 50;
    public decimal Discount => Total * (decimal)-0.05;
    public decimal Payable => Total + Vat + DeliveryCharge + Discount;

}