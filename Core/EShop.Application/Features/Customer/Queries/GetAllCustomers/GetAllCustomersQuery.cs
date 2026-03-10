using EShop.Application.DTOs.Customer;
using MediatR;

namespace EShop.Application.Features.Customer.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
{
}