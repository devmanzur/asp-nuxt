using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Utils;

namespace SimpleCart.Core.UseCases.AddToCart;

public class AddToCartCommand : IRequest<Result<CartDto>>
{
    public string ReferenceId { get; }
    public int ProductId { get; }
    public int Quantity { get; }

    public AddToCartCommand(string referenceId,int productId, int quantity)
    {
        ReferenceId = referenceId;
        ProductId = productId;
        Quantity = quantity;
    }
}

public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
{
    public AddToCartCommandValidator()
    {
        RuleFor(x => x.Quantity).Must(ValidationUtils.IsValidQuantity);
        RuleFor(x => x.ProductId).Must(ValidationUtils.IsValidEntityId);
        RuleFor(x => x.ReferenceId).Must(ValidationUtils.IsValidReferenceId);
    }

}