using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OccazNet.Core.Entities;

namespace OccazNet.Infrastructure
{
    public class SeedRole
    {
        public static async Task Initialize(IServiceProvider serviceProvider, RoleManager<Role> roleManager)
        {
            var roles = new[] { "Admin", "Acheteur", "Vendeur", "Visiteur" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { Name = role });
                }
            }
        }
    }
}
