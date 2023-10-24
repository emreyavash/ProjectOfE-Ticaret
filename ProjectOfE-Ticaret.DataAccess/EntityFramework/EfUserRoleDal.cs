using ProjectOfE_Ticaret.DataAccess.Abstract;
using ProjectOfE_Ticaret.DataAccess.ContextDb;
using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.EntityFramework
{
    public class EfUserRoleDal:EfEntityRepository<UserRole, ETicaretDbContext>,IUserRoleDal
    {
    }
}
