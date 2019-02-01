using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pharmalina.Application.Users.Commands.CreateUser;
using Pharmalina.Application.Users.Commands.DeleteUser;
using Pharmalina.Application.Users.Commands.UpdateUser;
using Pharmalina.Application.Users.Models;
using Pharmalina.Application.Users.Queries.Authentication;
using Pharmalina.Application.Users.Queries.GetAllUsers;
using Pharmalina.Application.Users.Queries.GetUser;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmalina.WebUI.Controllers
{

    public class UsersController : BaseController
    {
       [AllowAnonymous]
        [HttpPost("authenticate")]
        public Task<IActionResult> Authenticate([FromBody]UserDto userDto)
        {
            //var user = _userService.Authenticate(userDto.Username, userDto.Password);
            return Mediator.Send(new AuthenticateUserQuery { Username = userDto.Username, Password = userDto.Password });
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);

            return CreatedAtAction("GetUser", new { id = userId });
        }

        [HttpGet]
        public Task<UsersListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return Ok(await Mediator.Send(new GetUserQuery { Id = id }));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateUserCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }
    }
}
