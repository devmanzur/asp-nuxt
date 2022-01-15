using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Models.Orders;
using SimpleCart.Core.UseCases.Orders.CreateOrder;
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

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] ReferenceIdViewModel request)
    {
        var user = new Customer( User.GetIdentityClaimValue(AzureAdClaims.Username),User.GetIdentityClaimValue(AzureAdClaims.Name));
        var command = new CreateOrderCommand(user, request.ReferenceId);
        var createOrder = await _mediator.Send(command);
        if (createOrder.IsSuccess)
        {
            return Ok(Envelope<OrderDto>.Ok(createOrder.Value!));
        }

        return BadRequest(Envelope<OrderDto>.Error(createOrder.Error));
    }
}