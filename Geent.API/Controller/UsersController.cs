using Geent.Application.Interface.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Geent.Application.DTOs.Request;
using Geent.Application.Service;

namespace Geent.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Email, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequestDto userRegisterDto)
        {
            try
            {
                await _userService.RegisterUserAsync(userRegisterDto);
                return Ok(new { message = "Usuário registrado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("code-email")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserRequestDto request)
        {
            try
            {
                await _userService.VerifyUserAsync(request.Email, request.Code);
                return Ok(new { message = "Usuário verificado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var email = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { message = "Usuário não autenticado." });

                var user = await _userService.GetCurrentUserAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestDto request)
        {
            try
            {
                //var email = User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                //if (string.IsNullOrEmpty(email))
                //    return Unauthorized(new { message = "Usuário não autenticado." });

                await _userService.UpdateUserAsync(request.Email, request);
                return Ok(new { message = "Dados atualizados com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
