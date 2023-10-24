using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<Role> GetRoles(User user);
    }
}
