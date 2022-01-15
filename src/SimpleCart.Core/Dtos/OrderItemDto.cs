namespace SimpleCart.Core.Dtos;

public class OrderItemDto
{
    public decimal UnitPrice { get;  set; }
    public int Quantity { get;  set; }
    public int ProductId { get;  set; }
    public decimal TotalPrice => UnitPrice * Quantity;
    public string? ProductName { get; set; }
    public string? ProductImageUrl { get; set; }
}