using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerWriteRepository _writeRepository;
    private readonly ICustomerReadRepository _readRepository;

    public DeleteCustomerHandler(
        ICustomerWriteRepository writeRepository,
        ICustomerReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _readRepository.GetByIdAsync(request.Id);

        if (customer is null) return false;

        _writeRepository.Delete(customer);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}