using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Core.UseCases.Orders.ViewOrderDetails;

public class ViewOrderDetailsQuery : IRequest<Result<OrderDetailsDto>>
{
    public Customer Customer { get; }
    public string TrackingId { get; }

    public ViewOrderDetailsQuery(Customer customer, string trackingId)
    {
        Customer = customer;
        TrackingId = trackingId;
    }
}

public class ViewOrderDetailsQueryValidator : AbstractValidator<ViewOrderDetailsQuery>
{
    public ViewOrderDetailsQueryValidator()
    {
        RuleFor(x => x.Customer).NotNull().NotEmpty();
        RuleFor(x => x.Customer.Id).NotNull().NotEmpty();
        RuleFor(x => x.TrackingId).NotNull().NotEmpty();
    }
}