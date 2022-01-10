using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.UseCases.ViewCatalog;
using SimpleCart.Core.UseCases.ViewCategories;
using SimpleCart.Web.Models;

namespace SimpleCart.Web.Controllers;

public class CatalogController : BaseApiController
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Envelope<List<CatalogItemDto>>>> GetCatalogItems(
        [FromQuery] CatalogQueryViewModel request)
    {
        var query = new ViewCatalogQuery(new Segment(request.Size, request.Index), request.CategoryId);
        var items = await _mediator.Send(query);
        return Ok(Envelope<List<CatalogItemDto>>.Ok(items));
    }

    [HttpGet("categories")]
    public async Task<ActionResult<Envelope<List<CategoryDto>>>> GetCategories()
    {
        var query = new ViewCategoriesQuery();
        var items = await _mediator.Send(query);
        return Ok(Envelope<List<CategoryDto>>.Ok(items));
    }
}