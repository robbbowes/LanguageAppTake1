using System.Threading.Tasks;
using API.DTOs.Auth;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authService.Register(
                new AppUser { UserName = request.UserName }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authService.Login(request.UserName, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}