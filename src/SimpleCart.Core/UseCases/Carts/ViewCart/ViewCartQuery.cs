using MediatR;
using SimpleCart.Core.Dtos;

namespace SimpleCart.Core.UseCases.Carts.ViewCart;

public class ViewCartQuery : IRequest<CartDto>
{
    public ViewCartQuery(string referenceId)
    {
        ReferenceId = referenceId;
    }

    public string ReferenceId { get;}
}