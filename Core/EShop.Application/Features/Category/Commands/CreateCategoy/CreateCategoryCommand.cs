using MediatR;

namespace EShop.Application.Features.Category.Commands.CreateCategoy;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
