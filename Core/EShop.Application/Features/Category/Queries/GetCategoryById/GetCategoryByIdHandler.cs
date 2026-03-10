using EShop.Application.DTOs.Category;
using EShop.Application.DTOS.Category;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryReadRepository _readRepository;

    public GetCategoryByIdHandler(ICategoryReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _readRepository.GetByIdAsync(request.Id);

        if (category is null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}