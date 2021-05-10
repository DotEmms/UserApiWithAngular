using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService : IAppUserService
    {
        private MyFirstApiContext _context;
        private IMapper _mapper;
        public AppUserService(MyFirstApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<MemberDTO> GetMemberAsync(int id)
        {
            AppUser user = await GetUserAsync(id);
            MemberDTO member = _mapper.Map<MemberDTO>(user);
            return member;
        }
    }
}
