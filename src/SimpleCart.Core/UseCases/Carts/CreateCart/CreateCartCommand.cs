using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using SimpleCart.Core.Utils;

namespace SimpleCart.Core.UseCases.Carts.CreateCart;

public class CreateCartCommand : IRequest<Result>
{
    public CreateCartCommand(string referenceId)
    {
        ReferenceId = referenceId;
    }

    public string ReferenceId { get; }
}

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(x => x.ReferenceId).Must(ValidationUtils.IsValidReferenceId);
    }
}