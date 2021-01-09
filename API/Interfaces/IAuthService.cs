using System.Threading.Tasks;
using API.DTOs.AppUser;
using API.Entities;

namespace API.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetAuthenticatedUserDto>> Register(AppUser user, string password);
        Task<ServiceResponse<GetAuthenticatedUserDto>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}