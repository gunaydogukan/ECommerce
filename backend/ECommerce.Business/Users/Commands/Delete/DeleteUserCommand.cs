using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Users.Commands.Delete
{
    public class DeleteUserCommand : IBaseCommand<bool>, ICacheInvalidation
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-users",          
            $"user-{Id}",         
            $"user-me-{Id}"       
        };
    }
}