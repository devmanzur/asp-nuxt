using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.UseCases.ViewCatalog;

public class ViewCatalogQueryHandler : IRequestHandler<ViewCatalogQuery, List<CatalogItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewCatalogQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<CatalogItemDto>> Handle(ViewCatalogQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Products.Select(x => new CatalogItemDto()
        {
            Description = x.Description,
            Name = x.Name,
            Price = x.Price,
            CategoryId = x.CategoryId,
            ImageUri = x.ImageUri,
            ProductId = x.Id
        }).AsNoTracking();

        if (request.CategoryId.HasValue)
        {
            query = query.Where(x => x.CategoryId == request.CategoryId);
        }

        return query.Skip(request.Segment.Skip).Take(request.Segment.Size)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}