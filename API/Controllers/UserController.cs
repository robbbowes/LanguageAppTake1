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
        public async Task<ActionResult<GetUserDto>> GetUser(string userName)
        {
            return await _userService.GetUserAsync(userName);
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

    }
}