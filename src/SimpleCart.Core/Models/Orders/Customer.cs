namespace SimpleCart.Core.Models.Orders;

public class Customer
{
    public Customer(string? id, string? name)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name), "User name must be provided");
        }

        Id = id;
        Name = name;
    }

    public string Name { get; private set; }
    public string Id { get; private set; }
}