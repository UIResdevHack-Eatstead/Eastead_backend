using Eatstead.Application.Services.Abstractions;
using Eatstead.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Constants;
using Valuegate.Common.Types;

namespace Eatstead.Application.Commands
{
    public class LoginUserCommand : IRequest<APIResponse>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, APIResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ITokenService _tokenService;
            public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
            {
                _userManager = userManager;
                _tokenService = tokenService;
            }

            public async Task<APIResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.EmailAddress);

                if (user is null)
                {
                    return APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, ResponseMessages.NotFound);
                }

              /*  if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    return APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, ResponseMessages.EmailNotConfirmed);
                }
              */
                var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!checkPassword)
                {
                    return APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, data: null, ResponseMessages.NotFound);
                }

                return APIResponse.GetSuccessMessage(HttpStatusCode.Created, data: await _tokenService.CreateUserObject(user), ResponseMessages.LoginMessage);
            }
        }
    }
}
