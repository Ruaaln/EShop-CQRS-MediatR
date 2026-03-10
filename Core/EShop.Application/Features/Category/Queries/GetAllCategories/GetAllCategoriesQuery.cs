using EShop.Application.DTOS.Category;
using MediatR;

namespace EShop.Application.Features.Category.Queries.GetAllCategories;


public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}