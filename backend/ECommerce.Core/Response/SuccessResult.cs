using ECommerce.Core.Responses.Base;
using System.Net;

namespace ECommerce.Core.Responses;

public class SuccessResult : Result
{
    public SuccessResult(string message = "İşlem başarılı.", int statusCode = (int)HttpStatusCode.OK)
        : base(true, message, statusCode)
    {
    }
}