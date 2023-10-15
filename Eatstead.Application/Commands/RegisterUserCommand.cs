using Eatstead.Common.Helpers;
using Eatstead.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Constants;
using Valuegate.Common.Enums;
using Valuegate.Common.Types;

namespace Eatstead.Application.Commands
{
    public class RegisterUserCommand : IRequest<APIResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public RoleType RoleType { get; set; }
        public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, APIResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ILogger<RegisterUserCommandHandler> _logger;
            //private readonly IUserAuthenticationService _userAuthenticationService;
            public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, ILogger<RegisterUserCommandHandler> logger)
                     //IUserAuthenticationService userAuthenticationService)
            {
                _userManager = userManager;
                _logger = logger;
               // _userAuthenticationService = userAuthenticationService;
            }
            public async Task<APIResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var failedResponse = APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, ResponseMessages.FailedCreation);

                var newUser = new ApplicationUser()
                {
                    FirstName = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.EmailAddress,
                    Email = request.EmailAddress,
                    RolesCSV = request.RoleType.GetEnumDescription()
                };

                if (await _userManager.Users.AnyAsync(x => x.Email == request.EmailAddress))
                {
                    failedResponse.Data = new { message = ResponseMessages.UserExists, StatusCode = "400" };
                    return failedResponse;
                }

                var result = await _userManager.CreateAsync(newUser, request.Password);

                if (!result.Succeeded)
                {
                    failedResponse.Data = result.Errors.Select(x => x.Code + " : " + x.Description);
                    return failedResponse;
                }

                var addUserRole = await _userManager.AddToRoleAsync(newUser, request.RoleType.GetEnumDescription());
                if (!addUserRole.Succeeded)
                {
                    failedResponse.Data = addUserRole.Errors.Select(x => x.Code + " : " + x.Description);
                    return failedResponse;
                }

                var user = await _userManager.FindByEmailAsync(request.EmailAddress);
                if (user != null)
                {
                   /* var emailVerificationResult = await _userAuthenticationService.SendVerifyOTPToUserEmail(user, cancellationToken);
                    if (emailVerificationResult)
                        _logger.LogInformation($"Email Verification Send to User : {user.Id} on Email {user.Email} at {DateTime.Now}  ");
                    else
                    {
                        _logger.LogError($"Email Verification failed to Send to User : {user.Id} on Email {user.Email} at {DateTime.Now}  ");
                    }*/

                }

                return APIResponse.GetSuccessMessage(HttpStatusCode.Created, null, ResponseMessages.SuccessfulCreation);
            }
        }

    }
}
