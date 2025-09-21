using System.Net;
using System.Text.Json;
using ECommerce.Core.Exceptions.Base;
using ECommerce.Core.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ECommerce.Core.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(Microsoft.AspNetCore.Http.HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode statusCode;
        object response;

        switch (ex)
        {
            case ValidationException validationEx:
                statusCode = validationEx.StatusCode;
                response = new
                {
                    message = validationEx.Message,
                    errors = validationEx.Errors 
                };
                break;

            case BusinessException businessEx:
                statusCode = businessEx.StatusCode;
                response = new { message = businessEx.Message };
                break;

            case BaseException baseEx:
                statusCode = baseEx.StatusCode;
                response = new { message = baseEx.Message };
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                response = new { message = "Sunucuda beklenmeyen bir hata oluştu." };
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        var json = JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        );

        await context.Response.WriteAsync(json);
    }
}
