using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.UserAggregate;

public class ApplicationUser : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public AuthenticationProvider AuthenticationProvider { get; private set; }
    private readonly List<Address> _addresses = new List<Address>();
    public virtual IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

    public DateTime CreatedTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }

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
        this._addresses.Add(address);
    }
}