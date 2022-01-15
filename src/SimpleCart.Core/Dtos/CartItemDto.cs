namespace SimpleCart.Core.Dtos;

public class CartItemDto
{
    public decimal UnitPrice { get;  set; }
    public int Quantity { get;  set; }
    public int ProductId { get;  set; }
    public decimal TotalPrice => UnitPrice * Quantity;
    public string? ProductName { get; set; }
    public string? ProductImageUri { get; set; }
}