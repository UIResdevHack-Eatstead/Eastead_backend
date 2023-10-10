using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatstead.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RolesCSV { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastSeenDate { get; set; }

        public Cafeteria Cafeteria { get; set; }
    }
}
