using MediatR;
using SimpleCart.Core.Dtos;

namespace SimpleCart.Core.UseCases.ViewCategories;

public class ViewCategoriesQuery : IRequest<List<CategoryDto>>
{
    
}