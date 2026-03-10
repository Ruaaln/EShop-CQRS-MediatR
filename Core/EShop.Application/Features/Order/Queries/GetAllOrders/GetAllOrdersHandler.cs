using EShop.Application.DTOs.Order;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Order.Queries.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IOrderReadRepository _readRepository;

    public GetAllOrdersHandler(IOrderReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _readRepository.GetAllAsync();

        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            OrderNumber = o.OrderNumber,
            OrderDate = o.OrderDate,
            OrderNote = o.OrderNote,
            CustomerId = o.CustomerId,
            CustomerFullName = o.Customer != null
                ? $"{o.Customer.Name} {o.Customer.Surname}"
                : null
        }).ToList();
    }
}