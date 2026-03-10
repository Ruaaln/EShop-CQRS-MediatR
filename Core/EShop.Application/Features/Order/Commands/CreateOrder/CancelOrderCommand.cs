using MediatR;

namespace EShop.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public int CustomerId { get; set; }
    public string? OrderNote { get; set; }
    public List<OrderItemDto> Items { get; set; }
}

public class OrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}