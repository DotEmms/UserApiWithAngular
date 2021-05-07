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
        private AccountService _service;
        public AccountController(AccountService service)
        {
            _service = service;
        }
    }
}
