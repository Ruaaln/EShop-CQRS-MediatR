using MediatR;

namespace EShop.Application.Features.Order.Commands.CancelOrder;

public class CancelOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}