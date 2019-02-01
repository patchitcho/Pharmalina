using Pharmalina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Pharmalina.Application.Users.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static Expression<Func<User, UserDto>> Projection => p => new UserDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Username = p.UserName,
        };
    }
}
