using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using MediatR;

namespace EShop.Application.Features.Category.Commands.CreateCategoy;


public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryWriteRepository _writeRepository;

    public CreateCategoryHandler(ICategoryWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new EShop.Domain.Entities.Concretes.Category
        {
            Name = request.Name,
            Description = request.Description
        };


        await _writeRepository.AddAsync(category);
        await _writeRepository.SaveChangeAsync();

        return category.Id;
    }
}


