using MediatR;
using SimpleCart.Core.Dtos;

namespace SimpleCart.Core.UseCases.ViewCatalog;

public class ViewCatalogQuery : IRequest<List<CatalogItemDto>>
{
    
}