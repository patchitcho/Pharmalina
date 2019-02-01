using Pharmalina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Pharmalina.Application.Users.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public static Expression<Func<User, UserViewModel>> Projection
        {
            get
            {
                return p => new UserViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Username = p.UserName,
                    PasswordHash = p.PasswordHash,
                };
            }
        }
    }
}
