namespace EShop.Application.DTOS.Auth;

public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime ExpireDate { get; set; }
}