using AutoMapper;
using ProjectOfE_Ticaret.Business.Constants;
using ProjectOfE_Ticaret.DataAccess.Abstract;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using ProjectOfE_Ticaret.DataAccess.Results;
using ProjectOfE_Ticaret.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Business.Abstract
{
    public class UserRepository : IUserRepository
    {
        private IUserDal _repository;
        private readonly IMapper _mapper;

        public UserRepository(IUserDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public VoidResult Add(UserDTO entity)
        {
            var voidResult = new VoidResult();
            var userDTO = _mapper.Map<User>(entity);
            var isAdded= _repository.Add(userDTO);
            if (!isAdded)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotAdded;
                return voidResult;

            }
            voidResult.Success = true;
            voidResult.Message = Messages.Added;
            return voidResult;
        }

        public VoidResult Delete(UserDTO entity)
        {
            var voidResult = new VoidResult();
            var userDTO = _mapper.Map<User>(entity);

            var isDeleted = _repository.Delete(userDTO);
            if (!isDeleted)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotDeleted;
                return voidResult;

            }
            voidResult.Success = true;
            voidResult.Message = Messages.Deleted;
            return voidResult;
        }

        public  DataResult<UserDTO> GetByUserId(int id)
        {
            var dataResult = new DataResult<UserDTO>();
            var userContext = _repository.Get(x=>x.Id == id);
            var result = _mapper.Map<UserDTO>(userContext);
            if(result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public DataResult<UserDTO> GetByUserEmail(string email)
        {
            var userContext = _repository.Get(x => x.Email == email);
            var result = _mapper.Map<UserDTO>(userContext);

            var dataResult = new DataResult<UserDTO>();
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public DataResult<List<UserInfoDTO>> GetAll()
        {
            var userContext = _repository.GetAll();
            var result = _mapper.Map<List<UserInfoDTO>>(userContext);

            var dataResult = new DataResult<List<UserInfoDTO>>();
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Success = true;
            dataResult.Message = Messages.Listed;
            dataResult.Data = result;
            return dataResult;
        }

        public VoidResult Update(UserDTO entity)
        {
            var userDTO = _mapper.Map<User>(entity);

            var isUpdated = _repository.Update(userDTO);
            var voidResult = new VoidResult();
            if (!isUpdated)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotUpdated;
                return voidResult;

            }
            voidResult.Success = true;
            voidResult.Message = Messages.Updated;
            return voidResult;
        }

        public List<Role> GetRoles(User user)
        {
            var result = _repository.GetRoles(user);
            return result;
        }
    }
}
