using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Core.UseCases.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateOrderCommand> _validator;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateOrderCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var validateRequest = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateRequest.IsValid)
        {
            return Result.Failure<OrderDto>(validateRequest.Errors.FirstOrDefault()?.ErrorMessage);
        }

        Maybe<Cart?> cart = await _unitOfWork.Carts
            .Include(x => x.Items).ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.ReferenceId == request.CartReferenceId,
                cancellationToken: cancellationToken);
        if (cart.HasNoValue)
        {
            return Result.Failure<OrderDto>("Cart not found!");
        }

        var orderItems = cart.Value!.Items.Select(cartItem => new OrderItem(cartItem.Product, cartItem.Quantity))
            .ToList();
        var order = new Order(request.Customer, orderItems);
        _unitOfWork.Orders.Add(order);
        _unitOfWork.Carts.Remove(cart.Value!);
        await _unitOfWork.Commit();

        var response = new OrderDto()
        {
            TrackingId = order.TrackingId,
            ArrivalDate = order.DeliveryDate.ToString("D"),
            PaymentStatus = order.PaymentStatus.ToString(),
            PaymentType = order.PaymentType.ToString(),
            OrderStatus = order.Status.ToString(),
            PayableAmount = order.PayableAmount
        };

        return Result.Success(response);
    }
}