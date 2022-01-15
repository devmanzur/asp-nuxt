using MediatR;
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
        throw new NotImplementedException();
    }
}