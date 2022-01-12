using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.UseCases.Products.ViewCatalog;
using SimpleCart.Core.UseCases.Products.ViewCategories;
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
        var products = await _mediator.Send(query);
        return Ok(Envelope<List<CatalogItemDto>>.Ok(products));
    }

    [HttpGet("categories")]
    public async Task<ActionResult<Envelope<List<CategoryDto>>>> GetCategories()
    {
        var query = new ViewCategoriesQuery();
        var categories = await _mediator.Send(query);
        return Ok(Envelope<List<CategoryDto>>.Ok(categories));
    }
}