using EShop.Application.DTOs.Category;
using EShop.Application.DTOS.Category;
using MediatR;

namespace EShop.Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; set; }
}