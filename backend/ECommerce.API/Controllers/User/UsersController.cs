using ECommerce.Business.Users.Queries.GetUserById;
using ECommerce.Business.Users.Queries.GetAllUsers;
using ECommerce.Business.Users.Commands.Delete;
using ECommerce.Business.Users.Commands.Update;
using ECommerce.Business.Users.Queries.GetMe;
using MediatR;
using ECommerce.API.Controllers.Base;
using ECommerce.Business.Users.Commands.UpdateMe;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.API.Controllers.User
{
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Giriş yapmış kullanıcı getirir
        /// </summary>
        [HttpGet("me")]
        public async Task<IResult> GetMe(CancellationToken ct)
        {
            var user = await _mediator.Send(new GetMeQuery(), ct);
            return Success(user, "Kullanıcı bilgileri başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Tüm kullanıcıları getirir
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> GetAll(CancellationToken ct)
        {
            var users = await _mediator.Send(new GetAllUsersQuery(), ct);
            return Success(users, "Kullanıcılar başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Id’ye göre kullanıcı getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id, CancellationToken ct)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id), ct);
            return Success(user, "Kullanıcı başarıyla getirildi.", 200);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> Update(int id, [FromBody] UpdateUserCommand body, CancellationToken ct)
        {
            var command = body with { Id = id };
            var updated = await _mediator.Send(command, ct);
            return Success(updated, "Kullanıcı başarıyla güncellendi.", 200);
        }

        [HttpPut("update-me")]
        public async Task<IResult> UpdateMe([FromBody] UpdateMeCommand command, CancellationToken ct)
        {
            var updated = await _mediator.Send(command, ct);
            return Success(updated, "Kullanıcı başarıyla güncellendi.", 200);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteUserCommand(id), ct);
            return Success("Kullanıcı başarıyla silindi.", 200);
        }
    }
}
