using AutoMapper;
using ProjectOfE_Ticaret.Business.Constants;
using ProjectOfE_Ticaret.Core.Hashing;
using ProjectOfE_Ticaret.Core.JWT;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using ProjectOfE_Ticaret.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Business.Abstract
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthRepository(IUserRepository userRepository, ITokenHelper tokenHelper, IMapper mapper, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public AccessToken CreateAccessToken(UserDTO user)
        {
            var map = _mapper.Map<User>(user);
            var role = _userRepository.GetRoles(map);
            var accessToken = _tokenHelper.CreateToken(map, role);
            return accessToken;
        }

        public LoginResult Login(UserLoginDTO user)
        {
            var loginResult = new LoginResult();
           var userCheck = _userRepository.GetByUserEmail(user.Email);
            if (userCheck == null)
            {
                loginResult.Success = false;
                loginResult.Message = Messages.UserNotRegistered;
                return loginResult;
            }
            if(!HashingHelper.VerifyPassword(user.Password, userCheck.Data.PasswordHash,userCheck.Data.PasswordSalt))
            {
                loginResult.Success = false;
                loginResult.Message = Messages.WrongPassword;
                return loginResult;
            }
            loginResult.Success = true;
            loginResult.User = userCheck.Data;
            return loginResult;

        }

        public VoidResult Register(UserRegisterDTO user, string password)
        {
            var voidResult = new VoidResult();
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            UserDTO createUser = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BuyerOrSeller = user.BuyerOrSeller,
                CreateAtTime = user.CreateAtTime,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var result =_userRepository.Add(createUser);
            if (!result.Success)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.FailRegister;
                return voidResult;
            }
            var userRegistered = _userRepository.GetByUserEmail(user.Email);
       
            var roleName = userRegistered.Data.BuyerOrSeller ? "Seller" : "Buyer";
            var role = _roleRepository.GetRoleByRoleName(roleName);
            var userRole = new UserRoleDTO();
            userRole.UserId = userRegistered.Data.Id;
            userRole.RoleId = role.Data.Id;
            _userRoleRepository.Add(userRole);
            voidResult.Success = true;
            voidResult.Message = Messages.Register;
            return voidResult;
        }
        
    }
}
