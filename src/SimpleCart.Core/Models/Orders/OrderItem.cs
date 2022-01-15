using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Products;

namespace SimpleCart.Core.Models.Orders;

public class OrderItem : BaseEntity
{
    private OrderItem()
    {
        
    }
    
    public OrderItem( Product product, int quantity)
    {
        Product = product;
        UnitPrice = product.Price;
        Quantity = quantity;
        ProductId = product.Id;
    }

    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int OrderId { get; private set; }
    public Order Order { get; private set; }
    public decimal TotalPrice => this.UnitPrice * this.Quantity;
}