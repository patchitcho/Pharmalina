using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Pharmalina.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
