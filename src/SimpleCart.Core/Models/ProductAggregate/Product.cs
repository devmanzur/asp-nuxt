using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.ProductAggregate;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUri { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    
    
    public Product(Category category,string name, string description, decimal price, string imageUri)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUri = imageUri;
        CategoryId = category.Id;
    }
}