namespace ECommerce.Business.Users.Dtos
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
