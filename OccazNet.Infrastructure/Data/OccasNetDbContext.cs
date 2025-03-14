using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OccazNet.Core;
using OccazNet.Core.Entities;
namespace OccazNet.Infrastructure.Data
{
    public class OccasNetDbContext : IdentityDbContext<User,Role,Guid>
    {
        public OccasNetDbContext(DbContextOptions<OccasNetDbContext> options) : base(options) { }
    }
}
