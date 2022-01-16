namespace SimpleCart.Core.Dtos;

public class OrderDto
{
    public string TrackingId { get; set; }
    public decimal PayableAmount { get; set; }
    public string OrderStatus { get; set; }
    public string ArrivalDate { get; set; }
    public string PaymentType { get; set; }
    public string PaymentStatus { get; set; }
}

public class OrderDetailsDto : OrderDto
{
    public List<OrderItemDto> Items { get; set; }
    public decimal Total => Items.Any() ? Items.Select(x => x.TotalPrice).Sum() : 0;
    public decimal Vat { get; set; }
    public decimal DeliveryCharge { get; set; }
    public decimal Discount { get; set; }
}