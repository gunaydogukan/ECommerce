using System.Net;
using ECommerce.Core.Exceptions.Base;

namespace ECommerce.Core.Exceptions.Types;

public class ValidationException : BaseException
{
    public IReadOnlyDictionary<string, string> Errors { get; }

    public ValidationException(IEnumerable<(string Field, string Error)> errors)
        : base(HttpStatusCode.BadRequest, "Doğrulama hatası oluştu.")
    {
        Errors = errors.ToDictionary(e => e.Field, e => e.Error);
    }
}