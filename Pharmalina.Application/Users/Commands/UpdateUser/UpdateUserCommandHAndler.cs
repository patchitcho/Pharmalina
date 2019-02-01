using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Application.Exceptions;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Users.Commands.UpdateUser
{
    class UpdateUserCommandHAndler : IRequestHandler<UpdateUserCommand>
    {
        private readonly PharmalinaDbContext _context;
        public UpdateUserCommandHAndler(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            /*var user = _context.Users.Find(request.ID);

            if (user == null)
                throw new NotFoundException(nameof(user), request.ID);

            if (request.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.Username == request.Username))
                    throw new NotFoundException(nameof(user), request.ID);
            }

            // update user properties
            user.FirstName = request.Firstname;
            user.LastName = request.Lastname;
            user.Username = request.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordsHach.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                user.Passwordhash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);*/

            return Unit.Value;
        }
    }
}
