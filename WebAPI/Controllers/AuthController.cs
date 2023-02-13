using Business.Abstract;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (String.IsNullOrEmpty(userToLogin.FullName))
            {
                if(!String.IsNullOrEmpty(userToLogin.EmailAddress))
                    return BadRequest("Kullanıcı Sisteme kayıtlı değil");
                return BadRequest("Şifre hatalı");
            }

            var result = _authService.CreateAccessToken(userToLogin);
            return Ok(userToLogin);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExists(userForRegisterDto.Email);

            if (userExist)
            {
                return BadRequest("Kullanıcı Sisteme kayıtlı");
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult);

            if (result.Token is null)
            {
                return BadRequest("Token oluşturulamadı");
            }
            return Ok(result);
        }
    }
}
