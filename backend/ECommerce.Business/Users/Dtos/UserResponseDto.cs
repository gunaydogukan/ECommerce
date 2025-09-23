namespace ECommerce.Business.Users.Dtos
{
    public record UserResponseDto(
        string Email,
        string FirstName,
        string LastName,
        string PhoneNumber
    );
}