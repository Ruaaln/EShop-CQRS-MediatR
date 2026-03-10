using EShop.Application.DTOs.Customer;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Customer.Queries.GetAllCustomers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
{
    private readonly ICustomerReadRepository _readRepository;

    public GetAllCustomersHandler(ICustomerReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _readRepository.GetAllAsync();

        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Surname = c.Surname,
            Email = c.Email,
            ImageUrl = c.ImageUrl
        }).ToList();
    }
}