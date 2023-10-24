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

    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRolesController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet("UserRoles")]
        public IActionResult GetUserRoles()
        {
            var result = _userRoleRepository.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetRoleByUserId")]
        public IActionResult GetRoleByUserId(int userId)
        {
            var result = _userRoleRepository.GetByUserId(userId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole(UserRoleDTO userRole)
        {
            var result = _userRoleRepository.Add(userRole);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteUserRole")]
        public IActionResult DeleteUserRole(UserRoleDTO userRole)
        {
            var result = _userRoleRepository.Delete(userRole);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("UpdateUserRole")]
        public IActionResult UpdateUserRole(UserRoleDTO userRole)
        {
           var result= _userRoleRepository.Update(userRole);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
