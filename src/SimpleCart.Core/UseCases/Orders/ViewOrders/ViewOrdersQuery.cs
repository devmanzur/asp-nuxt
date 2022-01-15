using MediatR;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Core.UseCases.Orders.ViewOrders;

public class ViewOrdersQuery : IRequest<List<OrderDto>>
{
    public ViewOrdersQuery(Customer customer)
    {
        Customer = customer;
    }

    public Customer Customer { get; private set; }
}