using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Pharmalina.Application.Users.Models;

namespace Pharmalina.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public string Id { get; set; }
    }
}
