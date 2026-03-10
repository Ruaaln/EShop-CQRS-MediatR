using EShop.Application.Abstractions.Services;
using EShop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Infrastructure;

public static class RegisterService
{
    public static void AddInfrastructureRegister(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}