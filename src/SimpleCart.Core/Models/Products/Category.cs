using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.Products;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private readonly List<Product> _products = new List<Product>();

    public virtual IReadOnlyList<Product> Products => _products.AsReadOnly();

    private Category()
    {
        
    }
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
}