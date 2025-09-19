using ECommerce.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;

namespace ECommerce.API.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// başarılı 
    /// </summary>
    protected IResult Success(string message = "İşlem başarılı.", int statusCode = 200)
    {
        return new SuccessResult(message, statusCode);
    }

    /// <summary>
    /// Data + başarılı 
    /// </summary>
    protected IResult Success<T>(T data, string message = "İşlem başarılı.", int statusCode = 200)
    {
        return new SuccessDataResult<T>(data, message, statusCode);
    }

    /// <summary>
    /// hata 
    /// </summary>
    protected IResult Error(string message = "Bir hata oluştu.", int statusCode = 400)
    {
        return new ErrorResult(message, statusCode);
    }

    /// <summary>
    /// Data + hata 
    /// </summary>
    protected IResult Error<T>(T? data, string message = "Bir hata oluştu.", int statusCode = 400)
    {
        return new ErrorDataResult<T>(data, message, statusCode);
    }
}