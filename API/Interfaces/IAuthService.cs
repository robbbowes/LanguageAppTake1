using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(AppUser user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}