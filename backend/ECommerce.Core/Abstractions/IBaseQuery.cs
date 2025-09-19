using MediatR;

namespace ECommerce.Core.Abstractions;

public interface IBaseQuery<TResponse> : IRequest<TResponse>
{
}