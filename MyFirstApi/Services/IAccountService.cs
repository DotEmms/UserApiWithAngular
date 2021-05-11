using MyFirstApi.DTO;
using System.Threading.Tasks;

namespace MyFirstApi.Services
{
    public interface IAccountService
    {
        Task<UserDTO> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<UserDTO> LoginAsync(string name, string password);
    }
}