using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.UseCases.Carts.CreateCart;
using SimpleCart.Core.UseCases.Carts.UpdateCart;
using SimpleCart.Core.UseCases.Carts.ViewCart;
using SimpleCart.Web.Models;

namespace SimpleCart.Web.Controllers;

public class CartController : BaseApiController
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Envelope<CartDto>>> GetCart([FromQuery] ReferenceIdViewModel request)
    {
        var query = new ViewCartQuery(request.ReferenceId);
        var cart = await _mediator.Send(query);
        return Ok(Envelope<CartDto>.Ok(cart));
    }

    [HttpPost]
    public async Task<ActionResult<Envelope>> CreateCart([FromBody] ReferenceIdViewModel request)
    {
        var command = new CreateCartCommand(request.ReferenceId);
        var createCart = await _mediator.Send(command);
        if (createCart.IsSuccess)
        {
            return Ok(Envelope.Ok());
        }

        return BadRequest(Envelope.Error(createCart.Error));
    }

    [HttpPut]
    public async Task<ActionResult<Envelope<CartDto>>> UpdateCart([FromBody] CartItemViewModel request)
    {
        var command = new UpdateCartCommand(request.ReferenceId, request.ProductId, request.Quantity);
        var updateCart = await _mediator.Send(command);
        if (updateCart.IsSuccess)
        {
            return Ok(Envelope<CartDto>.Ok(updateCart.Value!));
        }

        return BadRequest(Envelope<CartDto>.Error(updateCart.Error));
    }
}