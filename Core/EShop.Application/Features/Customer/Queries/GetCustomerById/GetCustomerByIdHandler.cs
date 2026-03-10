using EShop.Application.DTOs.Customer;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerReadRepository _readRepository;

    public GetCustomerByIdHandler(ICustomerReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _readRepository.GetByIdAsync(request.Id);

        if (customer is null) return null;

        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Surname = customer.Surname,
            Email = customer.Email,
            ImageUrl = customer.ImageUrl
        };
    }
}