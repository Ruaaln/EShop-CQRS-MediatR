using EShop.Application.DTOs.Product;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Product.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductReadRepository _readRepository;

    public GetProductByIdHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetByIdAsync(request.Id);

        if (product is null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            ImageUrl = product.ImageUrl
        };
    }
}