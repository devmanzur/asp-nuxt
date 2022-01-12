namespace SimpleCart.Core.Dtos;

public class CartDto
{
    public string ReferenceId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    public decimal GrandTotal => Items.Any()? Items.Select(x => x.TotalPrice).Sum() : 0;
}