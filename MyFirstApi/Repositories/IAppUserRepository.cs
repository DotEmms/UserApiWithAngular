using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public interface IAppUserRepository
    {
        Task AddUserAsync(AppUser user);
        Task DeleteUserAsync(int id);
        Task<AppUser> GetUserAsync(int id);
        Task<List<AppUser>> GetUsersAsync();
        Task UpdateUserAsync(AppUser user);
    }
}