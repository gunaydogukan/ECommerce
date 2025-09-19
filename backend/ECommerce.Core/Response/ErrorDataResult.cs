using ECommerce.Core.Responses.Base;
using System.Net;

namespace ECommerce.Core.Responses;

public class ErrorDataResult<T> : Result
{
    public T? Data { get; }

    public ErrorDataResult(string message = "Bir hata oluştu.", int statusCode = (int)HttpStatusCode.BadRequest)
        : base(false, message, statusCode)
    {
    }

    public ErrorDataResult(T? data, string message = "Bir hata oluştu.", int statusCode = (int)HttpStatusCode.BadRequest)
        : base(false, message, statusCode)
    {
        Data = data;
    }
}