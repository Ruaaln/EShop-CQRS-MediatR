using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using MediatR;

namespace EShop.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerWriteRepository _writeRepository;

    public CreateCustomerHandler(ICustomerWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new EShop.Domain.Entities.Concretes.Customer
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Password = request.Password,
            ImageUrl = request.ImageUrl
        };

        await _writeRepository.AddAsync(customer);
        await _writeRepository.SaveChangeAsync();

        return customer.Id;
    }
}