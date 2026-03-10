using MediatR;

namespace EShop.Application.Features.Order.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest<bool>
{
    public int Id { get; set; }
}