using EShop.Application.DTOs.Product;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IProductReadRepository _readRepository;

    public GetAllProductsHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _readRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            ImageUrl = p.ImageUrl
        }).ToList();
    }
}