using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Products;

namespace SimpleCart.Core.UseCases.Carts.UpdateCart;

public class UpdateCartCommandCommandHandler : IRequestHandler<UpdateCartCommand, Result<CartDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateCartCommand> _validator;

    public UpdateCartCommandCommandHandler(IUnitOfWork unitOfWork,IValidator<UpdateCartCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<CartDto>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var requestValidation = await _validator.ValidateAsync(request, cancellationToken);
        if (!requestValidation.IsValid)
        {
            return Result.Failure<CartDto>(requestValidation.Errors.FirstOrDefault()?.ErrorMessage);
        }
        
        Maybe<Product?> product = await _unitOfWork.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId,
            cancellationToken: cancellationToken);
        if (product.HasNoValue)
        {
            return Result.Failure<CartDto>("Product not found!");
        }

        Maybe<Cart?> cart = await _unitOfWork.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.ReferenceId == request.ReferenceId,
                cancellationToken: cancellationToken);
        if (cart.HasNoValue)
        {
            return Result.Failure<CartDto>("Cart not found!");
        }
        
        cart.Value!.AddItem(product.Value!, request.Quantity);
        await _unitOfWork.Commit();

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

        return Result.Success(response);
    }

    private Cart CreateCart(UpdateCartCommand request) => new Cart(request.ReferenceId);

    private Task<Cart?> FindCart(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        return _unitOfWork.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.ReferenceId == request.ReferenceId,
                cancellationToken: cancellationToken);
    }
}