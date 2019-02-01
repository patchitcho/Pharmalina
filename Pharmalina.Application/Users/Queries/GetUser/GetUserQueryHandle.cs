using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Application.Users.Models;
using Pharmalina.Persistence;
using Microsoft.EntityFrameworkCore;
using Pharmalina.Application.Exceptions;

namespace Pharmalina.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandle : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly PharmalinaDbContext _context;
        public GetUserQueryHandle(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(u => u.Id == request.Id)
                .Select(UserViewModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            return user;
        }
    }
}
