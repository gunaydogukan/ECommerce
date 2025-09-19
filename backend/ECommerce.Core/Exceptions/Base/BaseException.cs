using System.Net;

namespace ECommerce.Core.Exceptions.Base;

public abstract class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; }

    protected BaseException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}