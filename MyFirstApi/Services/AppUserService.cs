using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.DTO;
using MyFirstApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _repo;
        private IMapper _mapper;
        public AppUserService(IAppUserRepository repo, IMapper mapper)
        {
            _repo = repo;
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
            return await _repo.GetUsersAsync();
        }
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _repo.GetUserAsync(id);
        }

        public async Task AddUserAsync(AppUser user)
        {
            await _repo.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            await _repo.UpdateUserAsync(user);
        }
        public async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteUserAsync(id);
        }
        public async Task<MemberDTO> GetMemberAsync(int id)
        {
            AppUser user = await _repo.GetUserAsync(id);
            MemberDTO member = _mapper.Map<MemberDTO>(user);
            return member;
        }
        public async Task<ICollection<MemberDTO>> GetMembersAsync()
        {
            List<AppUser> users = await _repo.GetUsersAsync();
            List<MemberDTO> members = _mapper.Map<List<MemberDTO>>(users);
            return members;
        }
    }
}
