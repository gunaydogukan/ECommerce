using MediatR;

namespace ECommerce.Core.Abstractions;

public interface IBaseCommand<TResponse> : IRequest<TResponse>
{
}