using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.Users;

public class ApplicationUser : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }
    public Address Address { get; private set; }

    private ApplicationUser()
    {
        
    }
    public ApplicationUser(string firstName, string lastName, string username,
        AuthenticationProvider authenticationProvider)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        AuthenticationProvider = authenticationProvider;
    }

    public void SaveAddress(Address address)
    {
        this.Address = address;
    }
}