using EShop.Application.DTOs.Order;
using MediatR;

namespace EShop.Application.Features.Order.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int Id { get; set; }
}