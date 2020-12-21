using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.AppUser;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync();
        Task<GetUserDto> GetUserAsync(string name);
    }
}