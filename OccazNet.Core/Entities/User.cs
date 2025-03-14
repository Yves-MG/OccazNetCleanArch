using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace OccazNet.Core.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
