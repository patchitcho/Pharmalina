using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Pharmalina.Application.Users.Queries.Authentication
{
    public class AuthenticateUserQuery : IRequest<IActionResult>
    {
        public string Username { get; set; }

        public string Password { get; set; }
               
    }
}
