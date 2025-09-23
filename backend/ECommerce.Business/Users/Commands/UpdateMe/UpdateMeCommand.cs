using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Commands.UpdateMe
{
    public record UpdateMeCommand : IBaseCommand<UserResponseDto>, ICacheInvalidation
    {
        internal int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string? CurrentPassword { get; set; }   
        public string? NewPassword { get; set; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-users",          
            $"user-{Id}",         
            $"user-me-{Id}"       
        };
    }
}