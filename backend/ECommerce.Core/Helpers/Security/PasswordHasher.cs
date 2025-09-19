using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Core.Helpers.Security
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            var computedHash = Convert.ToBase64String(hash);
            return computedHash == storedHash;
        }
    }
}