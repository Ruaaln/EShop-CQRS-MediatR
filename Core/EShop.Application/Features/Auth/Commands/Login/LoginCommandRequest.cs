using EShop.Application.DTOS.Auth;
using MediatR;

namespace EShop.Application.Features.Auth.Commands.Login;

public class LoginCommandRequest : IRequest<AuthResponseDto?>
{
    public LoginDto Model { get; set; } = null!;
}