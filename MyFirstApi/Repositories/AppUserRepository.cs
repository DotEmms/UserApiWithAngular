using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private MyFirstApiContext _context;
        public AppUserRepository(MyFirstApiContext context)
        {
            _context = context;
        }
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
