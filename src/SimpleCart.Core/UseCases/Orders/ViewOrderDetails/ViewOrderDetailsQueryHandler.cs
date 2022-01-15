using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Core.UseCases.Orders.ViewOrderDetails;

public class ViewOrderDetailsQueryHandler : IRequestHandler<ViewOrderDetailsQuery, Result<OrderDetailsDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewOrderDetailsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<OrderDetailsDto>> Handle(ViewOrderDetailsQuery request,
        CancellationToken cancellationToken)
    {
        Maybe<Order?> order = await _unitOfWork.Orders
            .Include(x => x.Items).ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(x =>
                    x.TrackingId == request.TrackingId && x.Customer.Id == request.Customer.Id,
                cancellationToken: cancellationToken);
        if (order.HasNoValue)
        {
            return Result.Failure<OrderDetailsDto>("Order not found!");
        }

        var details = new OrderDetailsDto()
        {
            TrackingId = order.Value!.TrackingId,
            Vat = order.Value!.Vat,
            DeliveryCharge = order.Value!.DeliveryCharge,
            Discount = order.Value!.Discount,
            ArrivalDate = order.Value!.DeliveryDate.ToString("D"),
            PaymentStatus = order.Value!.PaymentStatus.ToString(),
            PaymentType = order.Value!.PaymentType.ToString(),
            OrderStatus = order.Value!.Status.ToString(),
            PayableAmount = order.Value!.PayableAmount,
            Items = order.Value!.Items.Select(x => new OrderItemDto()
            {
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                UnitPrice = x.UnitPrice,
                ProductImageUri = x.Product.ImageUri,
            }).ToList()
        };
        
        return Result.Success(details);
    }
}