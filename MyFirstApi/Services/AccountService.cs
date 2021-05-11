using Microsoft.EntityFrameworkCore;
using MyFirstApi.DTO;
using MyFirstApi.Repositories;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDTO> RegisterAsync(string userName, string password)
        {
            return await _repo.RegisterAsync(userName, password);
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _repo.UserExists(userName);
        }

        public async Task<UserDTO> LoginAsync(string name, string password)
        {
            return await _repo.LoginAsync(name, password);
        }
        
    }
}