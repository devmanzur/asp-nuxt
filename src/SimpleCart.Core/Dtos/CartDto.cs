namespace SimpleCart.Core.Dtos;

public class CartDto
{
    public string ReferenceId { get; set; }
    public List<CartItemDto> Items { get; set; }
    public decimal GrandTotal => Items.Select(x => x.TotalPrice).Sum();
}