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
    public interface IUserRoleRepository
    {
        VoidResult Add(UserRoleDTO entity);
        VoidResult Delete(UserRoleDTO entity);
        VoidResult Update(UserRoleDTO entity);
        DataResult<List<UserRoleDTO>> GetAll();
        DataResult<List<UserRoleDTO>> GetByUserId(int userId);
        DataResult<List<UserRoleDTO>> GetByRoleId(int roleId);
    }
}
