using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Products;

namespace SimpleCart.Core.UseCases.AddToCart;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Result<CartDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AddToCartCommand> _validator;

    public AddToCartCommandHandler(IUnitOfWork unitOfWork,IValidator<AddToCartCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<CartDto>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
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

        var cart = await FindCart(request, cancellationToken) ?? CreateCart(request);
        cart.AddItem(product.Value!, request.Quantity);
        await _unitOfWork.Commit();

        var response = new CartDto()
        {
            ReferenceId = cart.ReferenceId,
            Items = cart.Items.Select(i => new CartItemDto()
            {
                Quantity = i.Quantity,
                ProductId = i.ProductId,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        return Result.Success(response);
    }

    private Cart CreateCart(AddToCartCommand request) => new Cart(request.ReferenceId);

    private Task<Cart?> FindCart(AddToCartCommand request, CancellationToken cancellationToken)
    {
        return _unitOfWork.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.ReferenceId == request.ReferenceId,
                cancellationToken: cancellationToken);
    }
}