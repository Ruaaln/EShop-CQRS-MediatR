using EShop.Application.DTOS.Auth;
using MediatR;

namespace EShop.Application.Features.Auth.Commands.Register;

public class RegisterCommandRequest : IRequest<string>
{
    public RegisterDto Model { get; set; } = null!;
}