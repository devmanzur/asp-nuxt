namespace SimpleCart.Core.Interfaces;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}
public interface IBusinessTaskRule
{
    Task<bool> IsBroken();

    string Message { get; }
}