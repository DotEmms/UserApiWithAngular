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

    
    public class AccountController : ControllerBase
    {
        private IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        //ActionResult, gives you a non-generic result
        public async Task<ActionResult<UserDTO>> RegisterAsync(RegisterDTO dto)
        {
            if (await _service.UserExists(dto.Name))
            {
                //BadRequest is a part of ActionResult
                return BadRequest("Username already exists.");
            }
            var user = await _service.RegisterAsync(dto.Name, dto.Password);
            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> LoginAsync(LoginDTO dto)
        {
            //this happens in AccountService, so not needed anymore
            //if (!await _service.UserExists(dto.Name))
            //{
            //    return Unauthorized("Invalid username.");
            //}
            try
            {
                UserDTO user = await _service.LoginAsync(dto.Name, dto.Password);
                return user;
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            
        }
        
    }
}
