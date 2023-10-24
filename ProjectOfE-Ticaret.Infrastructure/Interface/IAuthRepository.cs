using ProjectOfE_Ticaret.Core.JWT;
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
    public interface IAuthRepository
    {
        AccessToken CreateAccessToken(UserDTO user);
        VoidResult Register(UserRegisterDTO user, string password); 
        LoginResult Login(UserLoginDTO user);
    }
}
