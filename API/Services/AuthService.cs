using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.AppUser;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<GetAuthenticatedUserDto>> Login(string userName, string password)
        {
            ServiceResponse<GetAuthenticatedUserDto> response = new ServiceResponse<GetAuthenticatedUserDto>();
            AppUser user = await _context.AppUsers.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Username or password incorrect";
            }
            else
            {
                response.Data = CreateToken(user);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(AppUser user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists.";
            }
            else
            {
                Helpers.Utility.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();

                response.Data = user.Id;
            }
            return response;
        }

        public async Task<bool> UserExists(string userName)
        {
            bool userExists = false;
            if (await _context.AppUsers.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
            {
                userExists = true;
            }
            return userExists;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                bool match = true;
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        match = false;
                        break;
                    }
                }
                return match;
            }
        }

        private GetAuthenticatedUserDto CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string generatedToken = tokenHandler.WriteToken(token);
            return new GetAuthenticatedUserDto {
                UserName = user.UserName,
                UserRole = user.UserRole,
                Token = generatedToken
            };
        }
    }
}