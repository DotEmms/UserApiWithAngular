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
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAsync()
        {
            var result = await _service.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync(int id)
        {
            var result = await _service.GetUserAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(AppUser user)
        {
            await _service.AddUserAsync(user);
            return Created("", null);
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

        [HttpGet("Members/{id}")]
        public async Task<ActionResult<MemberDTO>> GetMemberAsync(int id)
        {
            MemberDTO member = await _service.GetMemberAsync(id);
            return Ok(member);
        }
        [HttpGet("Members")]
        public async Task<ActionResult<ICollection<MemberDTO>>> GetMembersAsync()
        {
            ICollection<MemberDTO> members = await _service.GetMembersAsync();
            return Ok(members);
        }
    }
}
