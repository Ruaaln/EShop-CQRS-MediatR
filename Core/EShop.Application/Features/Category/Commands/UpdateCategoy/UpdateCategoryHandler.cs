using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Category.Commands.UpdateCategoy;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryWriteRepository _writeRepository;
    private readonly ICategoryReadRepository _readRepository;

    public UpdateCategoryHandler(
        ICategoryWriteRepository writeRepository,
        ICategoryReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _readRepository.GetByIdAsync(request.Id);

        if (category is null) return false;

        category.Name = request.Name;
        category.Description = request.Description;

        _writeRepository.Update(category);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}