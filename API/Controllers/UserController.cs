using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.AppUser;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUser(string userName)
        {
            return await _userService.GetUserAsync(userName, false);
        }

        [HttpGet("{userName}/course")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserCourses(string userName)
        {
            return await _userService.GetUserAsync(userName, true);
        }
    
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetUserDto>>>> GetUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

    }
}