using EShop.Application.DTOS.Category;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryReadRepository _readRepository;

    public GetAllCategoriesHandler(ICategoryReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _readRepository.GetAllAsync();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }).ToList();
    }
}