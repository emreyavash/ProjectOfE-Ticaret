using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Entity
{
    public class UserRole:IEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
