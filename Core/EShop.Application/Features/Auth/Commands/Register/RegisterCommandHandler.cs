using EShop.Application.Helpers;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using MediatR;

namespace EShop.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, string>
{
    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public RegisterCommandHandler(
        ICustomerReadRepository customerReadRepository,
        ICustomerWriteRepository customerWriteRepository)
    {
        _customerReadRepository = customerReadRepository;
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task<string> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Model.Password != request.Model.RePassword)
            return "RePassword sehvdir";

        var users = await _customerReadRepository.GetAllAsync();
        var exists = users.Any(x => x.Email == request.Model.Email);

        if (exists)
            return "Bu email artiq qeydiyyatdan kecib";

        var customer = new EShop.Domain.Entities.Concretes.Customer
        {
            Name = request.Model.Name,
            Surname = request.Model.Surname,
            Email = request.Model.Email,
            Password = PasswordHelper.HashPassword(request.Model.Password)
        };

        await _customerWriteRepository.AddAsync(customer);
        await _customerWriteRepository.SaveChangeAsync();

        return "Qeydiyyat ugurla tamamlandi";
    }
}