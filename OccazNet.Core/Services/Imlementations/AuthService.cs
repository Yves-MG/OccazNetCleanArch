using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OccazNet.Core.Entities;
using OccazNet.Core.Models.Users;
using OccazNet.Core.Services.Interfaces;

namespace OccazNet.Core.Services.Imlementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ITokenService tokenService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<ServiceResult> LoginAsync(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.UserName);
            if (user == null)
                return (ServiceResult)ServiceResult.Failure("User not found.");

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.Succeeded)
            {
                var token = _tokenService.GenerateToken(user);

                return (ServiceResult)ServiceResult.Success("Login successful.", token);
            }

            return (ServiceResult)ServiceResult.Failure("Invalid login attempt.");
        }

        public async Task<ServiceResult> RegisterAsync(Register register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) != null)

                return (ServiceResult)ServiceResult.Failure("User already exists.");

            var user = new User
            {
                Email = register.Email,
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return (ServiceResult)ServiceResult.Failure("Failed to create user.");

            var roleResult = await _userManager.AddToRoleAsync(user, "Acheteur");

            if (!roleResult.Succeeded)
                return (ServiceResult)ServiceResult.Failure("Failed to assign role.");

            return (ServiceResult)ServiceResult.Success("User registered successfully.");

        }
    }
}
