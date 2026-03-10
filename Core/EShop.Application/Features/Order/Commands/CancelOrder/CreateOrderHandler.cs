using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Order.Commands.CancelOrder;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
{
    private readonly IOrderWriteRepository _writeRepository;
    private readonly IOrderReadRepository _readRepository;

    public CancelOrderHandler(
        IOrderWriteRepository writeRepository,
        IOrderReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _readRepository.GetByIdAsync(request.Id);

        if (order is null) return false;

        order.UpdatedAt = DateTime.UtcNow;

        _writeRepository.Update(order);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}