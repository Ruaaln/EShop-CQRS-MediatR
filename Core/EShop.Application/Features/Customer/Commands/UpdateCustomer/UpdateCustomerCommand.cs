using MediatR;

namespace EShop.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}