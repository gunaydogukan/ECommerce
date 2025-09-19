using System.Net;
using ECommerce.Core.Exceptions.Base;

namespace ECommerce.Core.Exceptions.Types
{
    /// <summary>
    /// Business hatalarinda kullanilan exception.
    /// 400 ıle yakalnır.
    /// </summary>
    public class BusinessException : BaseException
    {
        public BusinessException(string message)
            : base(HttpStatusCode.BadRequest, message) { }
    }
}