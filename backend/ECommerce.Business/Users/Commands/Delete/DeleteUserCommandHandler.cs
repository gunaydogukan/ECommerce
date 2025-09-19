using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteUserCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();

            var user = await userRepo.Query()
                .FirstOrDefaultAsync(u => u.Id == request.Id, ct);

            if (user == null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            await userRepo.DeleteAsync(user, ct);

            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}