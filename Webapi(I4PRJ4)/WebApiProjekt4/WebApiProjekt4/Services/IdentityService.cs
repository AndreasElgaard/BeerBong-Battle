using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProjekt4.Data.Dto;
using WebApiProjekt4.options;
using System.Security.Claims;

namespace WebApiProjekt4.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appsettings;

        public IdentityService(UserManager<IdentityUser> userManager, AppSettings appSettings)
        {
            _userManager = userManager;
            _appsettings = appSettings;
        }

        public async Task<AutehnticationResult> LoginAsync(string userName, string passWord)
        {
            var User = await _userManager.FindByNameAsync(userName);


            if (User == null)
            {
                return new AutehnticationResult
                {
                    ErrorMessage = new[] { "User Name Does not exsist" }
                };
            }

            var UserHasValidPassword = await _userManager.CheckPasswordAsync(User, passWord);

            if (!UserHasValidPassword)
            {
                return new AutehnticationResult
                {
                    ErrorMessage = new[] { "User password combination is wrong" }
                };
            }

            return GenerateAuthenticationResult(User);
        }

        public async Task<AutehnticationResult> RegisterAsync(string userName, string passWord)
        {
            var exsistingUser = await _userManager.FindByNameAsync(userName);


            if (exsistingUser != null)
            {
                return new AutehnticationResult
                {

                    ErrorMessage = new[] { "User with this UserName already exsist" }
                };
            }

            var newUser = new IdentityUser
            {
                UserName = userName
            };
            

            var createdUser = await _userManager.CreateAsync(newUser, passWord);

            if (!createdUser.Succeeded)
            {
                return new AutehnticationResult
                {
                    ErrorMessage = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResult(newUser);
        }

        private AutehnticationResult GenerateAuthenticationResult(IdentityUser user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);

            return new AutehnticationResult
            {
                Success = true,
                Token = tokenhandler.WriteToken(token)
            };
        }
    }
}
