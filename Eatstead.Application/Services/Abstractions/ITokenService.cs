using Eatstead.Application.DTOs;
using Eatstead.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatstead.Application.Services.Abstractions
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(ApplicationUser user);
        Task<UserDetailsDTO> CreateUserObject(ApplicationUser user);
    }
}
