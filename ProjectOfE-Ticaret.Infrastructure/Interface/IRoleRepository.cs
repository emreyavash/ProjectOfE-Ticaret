using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Infrastructure.Interface
{
    public interface IRoleRepository
    {
        VoidResult AddRole(RoleDTO role);
        VoidResult DeleteRole(RoleDTO role);
        VoidResult UpdateRole(RoleDTO role);
        DataResult<List<RoleDTO>> GetAll();
        DataResult<RoleDTO> GetRoleByRoleName(string roleName);
        DataResult<RoleDTO> GetRoleById(int id);
    }
}
