using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PI_TMS.API.Models.DTOs;
using TMS.Application.Models;
using TMS.Application.Services.Interfaces;
using TMS.Domain.Entites.Requests.User;

namespace PI_TMS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthCodeStore _authCodeStore;
        private readonly ILoginService _loginService;
        private readonly UserManager<UserModel> _userManager;
        private readonly IMailService _mailService;
        public AuthController(ILoginService loginService, UserManager<UserModel> userManager, AuthCodeStore codeStore, IMailService mailService)
        {
            _loginService = loginService;
            _userManager = userManager;
            _mailService = mailService;
            _authCodeStore = codeStore;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserRequest request)
        {
            var token = await _loginService.LoginAsync(request.Email, request.Password);
            if (token == null)
                return Unauthorized("Invalid credentials");


            return Ok(new { Token = token });
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthDTO auth)
        {
            var code = new Random().Next(100000, 999999).ToString();

            if (_authCodeStore == null)
                throw new Exception("AuthCodeStore is NULL");

            if (auth == null)
                throw new Exception("AuthDTO is NULL");

            if (string.IsNullOrEmpty(auth.Email))
                throw new Exception("Email is empty or NULL");

            _authCodeStore.SaveCode(auth.Email, code);

            await _mailService.SendEmailAsync(new SendEmailRequest(
                auth.Email,
                "Your authentication code",
                $"Your verification code is: {code}"
            ));

            return Ok("Verification code sent to your email.");
        }

        [HttpPost("Verify")]
        public IActionResult Verify([FromBody] VerifyDTO data)
        {
            var expectedCode = _authCodeStore.GetCode(data.Email);

            if (expectedCode == null)
                return BadRequest("Code expired or email not found.");

            if (expectedCode != data.Code)
                return Unauthorized("Invalid code.");

            return Ok("Authentication successful!");
        }
    }
}
