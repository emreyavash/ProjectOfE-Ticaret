using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.Infrastructure.Interface;

namespace ProjectOfE_Ticaret.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            var result =_userRepository.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userRepository.GetByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("UserAdd")]
        public IActionResult UserAdd(UserDTO user)
        {
            var result =_userRepository.Add(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("UserDelete")]
        public IActionResult UserDelete(UserDTO user)
        {
           var result = _userRepository.Delete(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UserUpdate")]
        public IActionResult UserUpdate(UserDTO user)
        {
            var result = _userRepository.Update(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("Roles")]
        public IActionResult GetRoles(User user) { 
            var result = _userRepository.GetRoles(user);
            return Ok(result);
        }
    }
}
