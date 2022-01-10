using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.ProductAggregate;

namespace SimpleCart.Core.Models.CartAggregate;

public class CartItem : BaseEntity
{
    public CartItem(Product product, int quantity = 1)
    {
        ProductId = product.Id;
        UnitPrice = product.Price;
        SetQuantity(quantity);
    }

    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int CartId { get; private set; }
    public Cart Cart { get; private set; }

    public void SetQuantity(int quantity)
    {
        this.Quantity = quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        var total = this.Quantity + quantity;
        SetQuantity(total);
    }
}