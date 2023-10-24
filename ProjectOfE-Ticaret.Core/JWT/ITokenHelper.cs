using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Core.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> roles);
    }
}
