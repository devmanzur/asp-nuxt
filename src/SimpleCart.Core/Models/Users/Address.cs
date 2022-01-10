using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.Users;

public class Address : BaseValueObject
{
    public string Title { get; private set; }
    public string Street { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string Country { get; private set; }

    public string ZipCode { get; private set; }

    private Address()
    {
        
    }

    public Address(string street, string city, string state, string country, string zipcode, string title)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
        Title = title;
    }
}