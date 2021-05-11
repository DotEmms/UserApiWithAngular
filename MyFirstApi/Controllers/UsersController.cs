using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.DTO;
using MyFirstApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IAppUserService _service;
        public UsersController(IAppUserService service)
        {
            //Dependency Injection
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            return await _service.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _service.GetUserAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(AppUser user)
        {
            await _service.AddUserAsync(user);
        }

        [HttpPut]
        public async Task PutAsync(AppUser user)
        {
            await _service.UpdateUserAsync(user);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.DeleteUserAsync(id);
        }

        [HttpGet("Member")]
        public async Task<ActionResult<MemberDTO>> GetMemberAsync(int id)
        {
            MemberDTO member = await _service.GetMemberAsync(id);
            return member;
        }
    }
}
