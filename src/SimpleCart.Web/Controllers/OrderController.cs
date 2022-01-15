using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Models.Orders;
using SimpleCart.Core.UseCases.Orders.CreateOrder;
using SimpleCart.Core.UseCases.Orders.ViewOrderDetails;
using SimpleCart.Core.UseCases.Orders.ViewOrders;
using SimpleCart.Web.Models;
using SimpleCart.Web.Utils;

namespace SimpleCart.Web.Controllers;

[Authorize]
public class OrderController : BaseApiController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Envelope<List<OrderDto>>>> GetOrders()
    {
        var customer = new Customer(User.GetIdentityClaimValue(AzureAdClaims.Username),
            User.GetIdentityClaimValue(AzureAdClaims.Name));
        var query = new ViewOrdersQuery(customer);
        var getOrders = await _mediator.Send(query);
        return Ok(Envelope<List<OrderDto>>.Ok(getOrders));
    }

    [HttpGet("{trackingId}")]
    public async Task<ActionResult<Envelope<OrderDetailsDto>>> GetOrderDetails(string trackingId)
    {
        var customer = new Customer(User.GetIdentityClaimValue(AzureAdClaims.Username),
            User.GetIdentityClaimValue(AzureAdClaims.Name));
        var query = new ViewOrderDetailsQuery(customer, trackingId);
        var getOrderDetails = await _mediator.Send(query);
        if (getOrderDetails.IsSuccess)
        {
            return Ok(Envelope<OrderDetailsDto>.Ok(getOrderDetails.Value!));
        }

        return BadRequest(Envelope<OrderDetailsDto>.Error(getOrderDetails.Error));
    }

    [HttpPost]
    public async Task<ActionResult<Envelope<OrderDto>>> CreateOrder([FromBody] ReferenceIdViewModel request)
    {
        var customer = new Customer(User.GetIdentityClaimValue(AzureAdClaims.Username),
            User.GetIdentityClaimValue(AzureAdClaims.Name));
        var command = new CreateOrderCommand(customer, request.ReferenceId);
        var createOrder = await _mediator.Send(command);
        if (createOrder.IsSuccess)
        {
            return Ok(Envelope<OrderDto>.Ok(createOrder.Value!));
        }

        return BadRequest(Envelope<OrderDto>.Error(createOrder.Error));
    }
}