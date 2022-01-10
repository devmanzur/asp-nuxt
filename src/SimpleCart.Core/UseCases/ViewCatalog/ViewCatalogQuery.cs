using MediatR;
using SimpleCart.Core.Dtos;

namespace SimpleCart.Core.UseCases.ViewCatalog;

public class ViewCatalogQuery : IRequest<List<CatalogItemDto>>
{
    public ViewCatalogQuery(Segment segment, int? categoryId)
    {
        Segment = segment;
        CategoryId = categoryId;
    }

    public int? CategoryId { get; private set; }
    public Segment Segment { get; private set; }
}