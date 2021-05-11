using System.Threading.Tasks;

namespace MyFirstApi.Repositories
{
    public interface IAccountRepository
    {
        Task<AppUser> LoginAsync(string name, string password);
        Task<AppUser> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}