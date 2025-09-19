namespace ECommerce.Core.Responses.Abstracts;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
    int StatusCode { get; }  
}