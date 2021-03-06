using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Dtos;
using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.UseCases.Products.ViewCategories;

public class ViewCategoriesQueryHandler : IRequestHandler<ViewCategoriesQuery, List<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<List<CategoryDto>> Handle(ViewCategoriesQuery request, CancellationToken cancellationToken)
    {
        return _unitOfWork.Categories.Select(x => new CategoryDto()
            {
                CategoryId = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .Take(request.Segment.Size)
            .Skip(request.Segment.Skip)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
}