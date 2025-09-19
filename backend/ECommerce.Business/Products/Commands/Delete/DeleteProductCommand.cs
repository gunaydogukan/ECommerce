using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using MediatR;

namespace ECommerce.Business.Products.Commands.Delete
{
    public class DeleteProductCommand : IBaseCommand<bool> , ICacheInvalidation
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            "all-products"
        };
    }
}