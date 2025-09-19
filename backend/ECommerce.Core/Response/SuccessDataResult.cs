using ECommerce.Core.Responses.Base;
using System.Net;

namespace ECommerce.Core.Responses;

public class SuccessDataResult<T> : Result
{
    public T Data { get; }

    public SuccessDataResult(T data, string message = "İşlem başarılı.", int statusCode = (int)HttpStatusCode.OK)
        : base(true, message, statusCode)
    {
        Data = data;
    }
}