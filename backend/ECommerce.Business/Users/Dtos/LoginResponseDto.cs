namespace ECommerce.Business.Users.Dtos
{
    public record LoginResponseDto(
        int UserId,
        string Email,
        string FullName
        //string Token
    );
}