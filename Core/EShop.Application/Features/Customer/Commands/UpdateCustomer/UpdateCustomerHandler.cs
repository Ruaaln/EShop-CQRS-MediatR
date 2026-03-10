using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerWriteRepository _writeRepository;
    private readonly ICustomerReadRepository _readRepository;

    public UpdateCustomerHandler(
        ICustomerWriteRepository writeRepository,
        ICustomerReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _readRepository.GetByIdAsync(request.Id);

        if (customer is null) return false;

        customer.Name = request.FirstName;
        customer.Surname = request.LastName;
        customer.UpdatedAt = DateTime.UtcNow;

        _writeRepository.Update(customer);
        await _writeRepository.SaveChangeAsync();

        return true;
    }
}