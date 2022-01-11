using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Products;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Core.Models.Carts;

public class Cart : BaseEntity
{
    public string ReferenceId { get; private set; }
    private readonly List<CartItem> _items = new List<CartItem>();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    private Cart()
    {
    }

    public Cart(string referenceId)
    {
        ReferenceId = referenceId;
    }


    public void AddItem(Product product, int quantity = 1)
    {
        var existingItem = _items.FirstOrDefault(x => x.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.SetQuantity(quantity);
            if (existingItem.Quantity == 0)
            {
                _items.Remove(existingItem);
            }
            return;
        }

        var item = new CartItem(product, quantity);
        if (item.Quantity > 0)
        {
            _items.Add(item);
        }
    }
}