using EShop.Application.DTOS.Auth;
using EShop.Domain.Entities.Concretes;

namespace EShop.Application.Abstractions.Services;

public interface IJwtTokenService
{
    AuthResponseDto CreateToken(Customer customer);
}