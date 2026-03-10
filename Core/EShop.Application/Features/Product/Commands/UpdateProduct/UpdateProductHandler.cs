using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductWriteRepository _writeRepository;
    private readonly IProductReadRepository _readRepository;

    public UpdateProductHandler(
        IProductWriteRepository writeRepository,
        IProductReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetByIdAsync(request.Id);

        if (product is null) return false;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.CategoryId = request.CategoryId;
        product.ImageUrl = request.ImageUrl;

        _writeRepository.Update(product);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}