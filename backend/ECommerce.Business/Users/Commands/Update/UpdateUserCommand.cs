using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Users.Commands.Update
{
    public class UpdateUserCommand : IBaseCommand<UserResponseDto> , ICacheInvalidation
    {
        internal int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-users",          
            $"user-{Id}",         
            $"user-me-{Id}"       
        };
    }
}