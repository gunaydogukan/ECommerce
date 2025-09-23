namespace ECommerce.Business.Users.Dtos
{
    public record UserLoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}