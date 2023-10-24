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
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Business.Abstract
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IUserRoleDal _repository;
        private readonly IMapper _mapper;
        public UserRoleRepository(IUserRoleDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public VoidResult Add(UserRoleDTO entity)
        {
            var userRoleDTO = _mapper.Map<UserRole>(entity);
           var isAdded = _repository.Add(userRoleDTO);
            var voidResult = new VoidResult();

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

        public VoidResult Delete(UserRoleDTO entity)
        {
            var userRoleDTO = _mapper.Map<UserRole>(entity);

            var isDeleted = _repository.Delete(userRoleDTO);
            var voidResult = new VoidResult();

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

        public DataResult<List<UserRoleDTO>> GetAll()
        {
            var dataResult = new DataResult<List<UserRoleDTO>>();

            var userRoleList = _repository.GetAll();
            var result = _mapper.Map<List<UserRoleDTO>>(userRoleList);

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

        public DataResult<List<UserRoleDTO>> GetByRoleId(int roleId)
        {
            var userRoleList = _repository.GetAll(x=>x.RoleId == roleId);
            var result = _mapper.Map<List<UserRoleDTO>>(userRoleList);

            var dataResult = new DataResult<List<UserRoleDTO>>();
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

        public DataResult<List<UserRoleDTO>> GetByUserId(int userId)
        {
            
            var userRoleList = _repository.GetAll(x => x.UserId == userId);
            var result = _mapper.Map<List<UserRoleDTO>>(userRoleList);
            var dataResult = new DataResult<List<UserRoleDTO>>();
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

        public VoidResult Update(UserRoleDTO entity)
        {
            var userRoleDTO = _mapper.Map<UserRole>(entity);

            var isUpdated =_repository.Update(userRoleDTO);
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
    }
}
