using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Product.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductWriteRepository _writeRepository;

    public CreateProductHandler(IProductWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new EShop.Domain.Entities.Concretes.Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            ImageUrl = request.ImageUrl
        };

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangeAsync();

        return product.Id;
    }
}