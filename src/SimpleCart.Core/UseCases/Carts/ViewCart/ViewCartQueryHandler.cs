using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;

namespace SimpleCart.Core.UseCases.Carts.ViewCart;

public class ViewCartQueryHandler : IRequestHandler<ViewCartQuery, CartDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewCartQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CartDto> Handle(ViewCartQuery request, CancellationToken cancellationToken)
    {
        Maybe<Cart?> cart = await _unitOfWork.Carts.FirstOrDefaultAsync(x => x.ReferenceId == request.ReferenceId,
            cancellationToken: cancellationToken);

        if (cart.HasNoValue) return new CartDto();
        
        var response = new CartDto()
        {
            ReferenceId = cart.Value!.ReferenceId,
            Items = cart.Value!.Items.Select(i => new CartItemDto()
            {
                Quantity = i.Quantity,
                ProductId = i.ProductId,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        return response;
    }
}