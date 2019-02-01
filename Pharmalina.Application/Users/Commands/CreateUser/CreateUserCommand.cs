using MediatR;

namespace Pharmalina.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

