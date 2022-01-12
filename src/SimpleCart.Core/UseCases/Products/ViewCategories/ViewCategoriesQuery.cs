using MediatR;
using SimpleCart.Core.Dtos;

namespace SimpleCart.Core.UseCases.Products.ViewCategories;

public class ViewCategoriesQuery : IRequest<List<CategoryDto>>
{
    
}