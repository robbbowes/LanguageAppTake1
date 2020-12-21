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

        public async Task<GetUserDto> GetUserAsync(string name)
        {
            AppUser appUser = await _context.AppUsers
                .Include(x => x.AppUserCourses).ThenInclude(y => y.Course)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == name.ToLower());
            return _mapper.Map<GetUserDto>(appUser);
        }

        public async Task<IEnumerable<GetUserDto>> GetUsersAsync()
        {
            List<AppUser> appUsers = await _context.AppUsers.ToListAsync();
            return appUsers.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        }
    }
}