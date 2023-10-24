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
    public class EfUserDal : EfEntityRepository<User, ETicaretDbContext>, IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (ETicaretDbContext context = new ETicaretDbContext()){
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, RoleName = role.RoleName };
                return result.ToList();
            }
        }
    }
}
