using MediatR;

namespace EShop.Application.Features.Category.Commands.DeleteCategoy;

public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}
