using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Persistence;
using Pharmalina.Application.Exceptions;
using Pharmalina.Domain.Entities;

namespace Pharmalina.Application.Users.Commands.DeleteUser
{
    class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly PharmalinaDbContext _context;

        public DeleteUserCommandHandler(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Find(request.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
