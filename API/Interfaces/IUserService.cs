using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.AppUser;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<GetUserDto>>> GetUsersAsync();
        Task<ServiceResponse<GetUserDto>> GetUserAsync(string name, bool includeCourses);
    }
}