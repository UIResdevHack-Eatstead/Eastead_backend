using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Common.Enums;

namespace Eatstead.Application.DTOs
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public RoleType RoleType { get; set; }
    }
}
