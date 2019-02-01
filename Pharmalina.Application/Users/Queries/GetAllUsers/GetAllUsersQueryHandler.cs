using MediatR;
using Pharmalina.Application.Users.Models;
using Pharmalina.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pharmalina.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersListViewModel>
    {
        private readonly PharmalinaDbContext _context;

        public GetAllUsersQueryHandler(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<UsersListViewModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var model = new UsersListViewModel
            {
                Users = await _context.Users
                    .Select(UserDto.Projection)
                    .OrderBy(p => p.Username)
                    .ToListAsync(cancellationToken),
                // CreateEnabled = true
            };

            return model;
        }
    }
}
