using MyFirstApi.DTO;
using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public interface IAccountRepository
    {
        Task<UserDTO> LoginAsync(string name, string password);
        Task<UserDTO> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}