using EShop.Application.DTOs.Customer;
using MediatR;

namespace EShop.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }
}