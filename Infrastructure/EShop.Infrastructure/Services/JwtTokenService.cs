using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EShop.Application.Abstractions.Services;
using EShop.Application.DTOS.Auth;
using EShop.Domain.Entities.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AuthResponseDto CreateToken(Customer customer)
    {
        var issuer = _configuration["Jwt:Issuer"]!;
        var audience = _configuration["Jwt:Audience"]!;
        var secretKey = _configuration["Jwt:SecretKey"]!;
        var expireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"]!);

        var expireDate = DateTime.UtcNow.AddMinutes(expireMinutes);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{customer.Name} {customer.Surname}"),
            new Claim(ClaimTypes.Email, customer.Email ?? string.Empty)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expireDate,
            signingCredentials: credentials
        );

        return new AuthResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Email = customer.Email ?? string.Empty,
            FullName = $"{customer.Name} {customer.Surname}",
            ExpireDate = expireDate
        };
    }
}