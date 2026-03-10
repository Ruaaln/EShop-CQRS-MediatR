using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        var hasher = new PasswordHasher<object>();
        return hasher.HashPassword(new object(), password);
    }

    public static bool VerifyPassword(string hashedPassword, string password)
    {
        var hasher = new PasswordHasher<object>();
        var result = hasher.VerifyHashedPassword(new object(), hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}