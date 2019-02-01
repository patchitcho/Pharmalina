using MediatR;
using Pharmalina.Application.Users.Models;

namespace Pharmalina.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<UsersListViewModel>
    {
    }
}
