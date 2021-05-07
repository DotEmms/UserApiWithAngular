﻿using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<AppUser> LoginAsync(string name, string password);
    }
}