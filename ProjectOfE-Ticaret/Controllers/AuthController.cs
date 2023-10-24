using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.Infrastructure.Interface;

namespace ProjectOfE_Ticaret.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var result = _authRepository.Login(userLoginDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            var createToken = _authRepository.CreateAccessToken(result.User);
            if (createToken != null)
            {
                return Ok(createToken);
            }
            return BadRequest("Başarısız");
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDTO user )
        {
           var result= _authRepository.Register(user, user.Password);
            if (result.Success == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
