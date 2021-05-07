using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AccountService : IAccountService
    {
        private MyFirstApiContext _context;

        public AccountService(MyFirstApiContext context)
        {
            _context = context;
        }

        public async Task<AppUser> RegisterAsync(string userName, string password)
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

            return user;
        }
        public async Task<bool> UserExists(string userName)
        {

            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }
        public async Task<AppUser> LoginAsync(string name, string password)
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
            

            return user;
        }
        
    }
}
