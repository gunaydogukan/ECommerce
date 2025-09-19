using ECommerce.Core.Responses.Base;
using System.Net;

namespace ECommerce.Core.Responses;

public class ErrorResult : Result
{
    public ErrorResult(string message = "Bir hata oluştu.", int statusCode = (int)HttpStatusCode.BadRequest)
        : base(false, message, statusCode)
    {
    }
}