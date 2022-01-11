using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Products;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Core.Models.Carts;

public class Cart : BaseEntity
{
    public int OwnerId { get; private set; }
    public ApplicationUser Owner { get; private set; }
    private readonly List<CartItem> _items = new List<CartItem>();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    private Cart()
    {
        
    }

    public Cart(ApplicationUser owner)
    {
        OwnerId = owner.Id;
    }
    
    public void AddItem(Product product, decimal unitPrice, int quantity = 1)
    {
        var existingItem = Items.FirstOrDefault(x => x.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.IncreaseQuantity(quantity);
            return;
        }

        _items.Add(new CartItem(product, quantity));
    }
}