using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductWriteRepository _writeRepository;
    private readonly IProductReadRepository _readRepository;

    public DeleteProductHandler(
        IProductWriteRepository writeRepository,
        IProductReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetByIdAsync(request.Id);

        if (product is null) return false;

        _writeRepository.Delete(product);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}