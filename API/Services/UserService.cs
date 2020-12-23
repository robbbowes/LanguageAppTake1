using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.AppUser;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserAsync(string name, bool includeCourses)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            AppUser appUser;
            if (includeCourses)
            {
                appUser = await _context.AppUsers
                    .Include(x => x.AppUserCourses).ThenInclude(y => y.Course)
                    .FirstOrDefaultAsync(u => u.UserName.ToLower() == name.ToLower());
            }
            else
            {
                appUser = await _context.AppUsers
                    .FirstOrDefaultAsync(u => u.UserName.ToLower() == name.ToLower());
            }

            if (appUser == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else
            {
                response.Data = _mapper.Map<GetUserDto>(appUser);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetUserDto>>> GetUsersAsync()
        {
            ServiceResponse<IEnumerable<GetUserDto>> response = new ServiceResponse<IEnumerable<GetUserDto>>();
            List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
            response.Data = appUsers.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return response;
        }
    }
}