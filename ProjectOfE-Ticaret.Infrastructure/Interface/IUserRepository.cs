using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Infrastructure.Interface
{
    public interface IUserRepository 
    {
        VoidResult Add(UserDTO entity);
        VoidResult Delete(UserDTO entity);
        VoidResult Update(UserDTO entity);
        DataResult<List<UserInfoDTO>> GetAll();
        DataResult<UserDTO> GetByUserId(int id);
        DataResult<UserDTO> GetByUserEmail(string email);
        List<Role> GetRoles(User user);

    }
}
