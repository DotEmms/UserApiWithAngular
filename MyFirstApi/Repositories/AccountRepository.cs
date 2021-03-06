using Microsoft.EntityFrameworkCore;
using MyFirstApi.DTO;
using MyFirstApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private MyFirstApiContext _context;
        private ITokenService _tokenService;
        public AccountRepository(MyFirstApiContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;

        }

        public async Task<UserDTO> RegisterAsync(string userName, string password)
        {
            //keep this code for future references
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Name = userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserName = user.Name,
                Token = _tokenService.CreateToken(user),
            };
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }

        public async Task<UserDTO> LoginAsync(string name, string password)
        {
            AppUser user = await _context.Users.SingleOrDefaultAsync(x => x.Name == name);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username.");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i])
                {
                    throw new UnauthorizedAccessException("Invalid password.");
                }
            }

            return new UserDTO
            {
                UserName = user.Name,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
