using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;

namespace SimpleCart.Core.UseCases.Carts.CreateCart;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCartCommand> _validator;

    public CreateCartCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCartCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var validateRequest = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateRequest.IsValid)
        {
            return Result.Failure(validateRequest.Errors.FirstOrDefault()?.ErrorMessage);
        }

        var cartWithSameReferenceExists = await _unitOfWork.Carts.AnyAsync(x => x.ReferenceId == request.ReferenceId,
            cancellationToken: cancellationToken);
        if (cartWithSameReferenceExists)
        {
            return Result.Failure("Another cart with same reference already exists");
        }

        var cart = new Cart(request.ReferenceId);
        _unitOfWork.Carts.Add(cart);
        await _unitOfWork.Commit();

        return Result.Success();
    }
}