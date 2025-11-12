using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PI_TMS.API.Models.DTOs;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites.Requests.User;

namespace PI_TMS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<UserModel> _userManager;
        public AuthController(ILoginService loginService, UserManager<UserModel> userManager)
        {
            _loginService = loginService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserRequest request)
        {
            var token = await _loginService.LoginAsync(request.Email, request.Password);
            if (token == null)
                return Unauthorized("Invalid credentials");

                
            return Ok(new { Token = token });
        }

        public async Task<IActionResult> Authenticate([FromBody] UserForAuthDTO userForAuthDTO)
        {

        }
    }
}
