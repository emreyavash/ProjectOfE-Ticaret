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
    [Authorize(Roles = "Admin")]

    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("Roles")]
        public IActionResult GetRoles()
        {
            var result = _roleRepository.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddRole")]
        public IActionResult AddRole(RoleDTO role)
        {
            var result = _roleRepository.AddRole(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(RoleDTO role)
        {
            var result = _roleRepository.DeleteRole(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole(RoleDTO role)
        {
            var result = _roleRepository.UpdateRole(role);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
