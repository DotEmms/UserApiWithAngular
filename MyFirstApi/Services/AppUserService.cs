using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService : IAppUserService
    {
        private MyFirstApiContext _context;
        public AppUserService(MyFirstApiContext context)
        {
            _context = context;
        }
        // => not needed anymore
        //private List<AppUser> _users = new List<AppUser>
        //{
        //    new AppUser{Id = 1, Name = "Michiel"},
        //    new AppUser{Id = 2, Name = "Kenny"},
        //    new AppUser{Id = 3, Name = "Stan"},
        //    new AppUser{Id = 4, Name = "Kyle"},
        //    new AppUser{Id = 5, Name = "Eric"},
        //};

        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = new AppUser { Id = id };
            _context.Attach(user);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}
