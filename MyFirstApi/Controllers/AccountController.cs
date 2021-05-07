using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<AppUser> RegisterAsync(string name, string password)
        {
            var user = await _service.RegisterAsync(name, password);
            return user;
        }



    }
}
