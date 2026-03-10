using EShop.Application.Abstractions.Services;
using EShop.Application.DTOS.Auth;
using EShop.Application.Helpers;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, AuthResponseDto?>
{
    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginCommandHandler(
        ICustomerReadRepository customerReadRepository,
        IJwtTokenService jwtTokenService)
    {
        _customerReadRepository = customerReadRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResponseDto?> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var users = await _customerReadRepository.GetAllAsync();
        var user = users.FirstOrDefault(x => x.Email == request.Model.Email);

        if (user is null)
            return null;

        var isValid = PasswordHelper.VerifyPassword(user.Password!, request.Model.Password);

        if (!isValid)
            return null;

        return _jwtTokenService.CreateToken(user);
    }
}