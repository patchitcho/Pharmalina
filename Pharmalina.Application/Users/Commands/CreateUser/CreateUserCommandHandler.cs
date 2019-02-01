using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Persistence;
using Pharmalina.Domain.Entities;
using System;
using Microsoft.AspNetCore.Identity;

namespace Pharmalina.Application.Users.Commands.CreateUser
{
    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly PharmalinaDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(PharmalinaDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            
            return user.Id;
        }
    }
}
