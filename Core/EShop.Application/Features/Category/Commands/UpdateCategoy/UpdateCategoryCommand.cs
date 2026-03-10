using MediatR;

namespace EShop.Application.Features.Category.Commands.UpdateCategoy;

public class UpdateCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}