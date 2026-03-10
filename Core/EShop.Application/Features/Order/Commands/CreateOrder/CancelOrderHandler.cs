using EShop.Application.Repositories;
using EShop.Domain.Entities;
using EShop.Domain.Entities.Concretes;
using MediatR;

namespace EShop.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderWriteRepository _writeRepository;
    private readonly IProductReadRepository _productReadRepository;

    public CreateOrderHandler(
        IOrderWriteRepository writeRepository,
        IProductReadRepository productReadRepository)
    {
        _writeRepository = writeRepository;
        _productReadRepository = productReadRepository;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderItems = new List<OrderItem>();

        foreach (var item in request.Items)
        {
            var product = await _productReadRepository.GetByIdAsync(item.ProductId);

            if (product is null)
                throw new Exception($"Məhsul tapılmadı: {item.ProductId}");

            orderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
        }

        var order = new EShop.Domain.Entities.Concretes.Order
        {
            CustomerId = request.CustomerId,
            OrderNumber = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
            OrderDate = DateTime.UtcNow,
            OrderNote = request.OrderNote,
            Total = orderItems.Sum(x => (decimal)(x.UnitPrice * x.Quantity))
        };

        await _writeRepository.AddAsync(order);
        await _writeRepository.SaveChangeAsync();

        return order.Id;
    }
}