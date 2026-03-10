using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Category.Commands.DeleteCategoy;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryWriteRepository _writeRepository;
    private readonly ICategoryReadRepository _readRepository;

    public DeleteCategoryHandler(
        ICategoryWriteRepository writeRepository,
        ICategoryReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _readRepository.GetByIdAsync(request.Id);

        if (category is null) return false;

        _writeRepository.Delete(category.Id);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}