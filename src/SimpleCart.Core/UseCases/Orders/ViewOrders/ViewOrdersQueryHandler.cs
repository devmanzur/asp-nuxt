using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.UseCases.Orders.ViewOrders;

public class ViewOrdersQueryHandler : IRequestHandler<ViewOrdersQuery,List<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewOrdersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<OrderDto>> Handle(ViewOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.AsNoTracking()
            .Where(x => x.Customer.Id == request.Customer.Id)
            .Select(order => new OrderDto()
            {
                TrackingId = order.TrackingId,
                ArrivalDate = order.DeliveryDate.ToString("D"),
                PaymentStatus = order.PaymentStatus.ToString(),
                PaymentType = order.PaymentType.ToString(),
                OrderStatus = order.Status.ToString(),
                PayableAmount = order.PayableAmount
            }).ToListAsync(cancellationToken: cancellationToken);

        return orders;
    }
}