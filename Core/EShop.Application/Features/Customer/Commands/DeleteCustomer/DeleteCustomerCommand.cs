using MediatR;

namespace EShop.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<bool>
{
    public int Id { get; set; }
}