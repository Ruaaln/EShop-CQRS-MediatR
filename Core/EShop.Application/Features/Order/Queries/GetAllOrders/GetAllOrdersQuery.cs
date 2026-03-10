using EShop.Application.DTOs.Order;
using MediatR;

namespace EShop.Application.Features.Order.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<List<OrderDto>>
{
}