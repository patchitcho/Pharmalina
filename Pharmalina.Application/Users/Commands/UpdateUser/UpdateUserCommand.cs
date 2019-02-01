using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Pharmalina.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
