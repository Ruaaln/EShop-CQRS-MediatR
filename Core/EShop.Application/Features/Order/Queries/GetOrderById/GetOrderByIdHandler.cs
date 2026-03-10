using EShop.Application.DTOs.Order;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Order.Queries.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderReadRepository _readRepository;

    public GetOrderByIdHandler(IOrderReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _readRepository.GetByIdAsync(request.Id);

        if (order is null) return null;

        return new OrderDto
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            OrderNote = order.OrderNote,
            CustomerId = order.CustomerId,
            CustomerFullName = order.Customer != null
                ? $"{order.Customer.Name} {order.Customer.Surname}"
                : null
        };
    }
}