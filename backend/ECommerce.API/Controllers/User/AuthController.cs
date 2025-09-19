using ECommerce.API.Controllers.Base;
using ECommerce.Business.Users.Commands.Login;
using ECommerce.Business.Users.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;

namespace ECommerce.API.Controllers.User
{
    [AllowAnonymous] 
    [Route("api/[controller]/auth")]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Kullanıcı kayıt işlemi
        /// </summary>
        [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);
            return Success(data, "Kullanıcı başarıyla kaydedildi.", 201);
        }

        /// <summary>
        /// Kullanıcı giriş işlemi
        /// </summary>
        [HttpPost("login")]
        public async Task<IResult> Login(LoginUserCommand command, CancellationToken ct)
        {
            var loginResult = await _mediator.Send(command, ct);
            return Success(loginResult, "Giriş başarılı.", 200);
        }
    }
}