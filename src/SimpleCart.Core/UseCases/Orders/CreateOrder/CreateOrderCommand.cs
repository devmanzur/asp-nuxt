using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Core.UseCases.Orders.CreateOrder;

public class CreateOrderCommand : IRequest<Result<OrderDto>>
{
    public Customer Customer { get; }
    public string CartReferenceId { get; }

    public CreateOrderCommand(Customer customer, string cartReferenceId)
    {
        Customer = customer;
        CartReferenceId = cartReferenceId;
    }
}

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Customer).NotNull().NotEmpty();
        RuleFor(x => x.Customer.Id).NotNull().NotEmpty();
        RuleFor(x => x.Customer.Name).NotNull().NotEmpty();
        RuleFor(x => x.CartReferenceId).NotNull().NotEmpty();
    }
}