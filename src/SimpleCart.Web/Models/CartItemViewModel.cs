namespace SimpleCart.Web.Models;

public class CartItemViewModel
{
    public string ReferenceId { get; set; }
    public int ProductId { get; }
    public int Quantity { get; }
}