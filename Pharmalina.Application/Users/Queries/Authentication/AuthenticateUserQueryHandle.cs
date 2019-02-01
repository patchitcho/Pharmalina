using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pharmalina.Application.Exceptions;
using Pharmalina.Application.Users.Helpers;
using Pharmalina.Application.Users.Models;
using Pharmalina.Domain.Entities;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pharmalina.Application.Users.Queries.Authentication
{
    public class AuthenticateUserQueryHandle : IRequestHandler<AuthenticateUserQuery, IActionResult>
    {
        private readonly UserManager<User> _userManager;
        private IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthenticateUserQueryHandle(UserManager<User> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }
        

        public async Task<IActionResult> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var identity = await GetClaimsIdentity(request.Username, request.Password);
            if (identity == null)
            {
                throw new NotFoundException(request.Username, null);
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, request.Username, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var userToVerify = await _userManager.FindByNameAsync(userName);

            // check if username exists
            if (userToVerify == null)
                return null;

            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
