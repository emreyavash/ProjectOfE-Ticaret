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
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleDal _repository;
        private readonly IMapper _mapper;
        public RoleRepository(IRoleDal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public VoidResult AddRole(RoleDTO role)
        {
            var voidResult = new VoidResult();
            Role roleDto = _mapper.Map<Role>(role);

            var isAdded = _repository.Add(roleDto);
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

        public VoidResult DeleteRole(RoleDTO role)
        {
            var voidResult = new VoidResult();
            var roleDto = _mapper.Map<Role>(role);

            var isDeleted = _repository.Delete(roleDto);
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

        public DataResult<List<RoleDTO>> GetAll()
        {
            var dataResult = new DataResult<List<RoleDTO>>();
            var listRole = _repository.GetAll();
            var result = _mapper.Map<List<RoleDTO>>(listRole);
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Data = result;
            dataResult.Message = Messages.Listed;
            dataResult.Success = true;
            return dataResult;
        }

        public DataResult<RoleDTO> GetRoleById(int id)
        {
            var dataResult = new DataResult<RoleDTO>();
            var getRole = _repository.Get(x => x.Id == id);
            var result = _mapper.Map<RoleDTO>(getRole);
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Data = result;
            dataResult.Message = Messages.Listed;
            dataResult.Success = true;
            return dataResult;
        }

        public DataResult<RoleDTO> GetRoleByRoleName(string roleName)
        {
            var dataResult = new DataResult<RoleDTO>();
            var getRole = _repository.Get(x => x.RoleName == roleName);
            var result = _mapper.Map<RoleDTO>(getRole);
            if (result == null)
            {
                dataResult.Success = false;
                dataResult.Message = Messages.NotListed;
                return dataResult;
            }
            dataResult.Data = result;
            dataResult.Message = Messages.Listed;
            dataResult.Success = true;
            return dataResult;
        }

        public VoidResult UpdateRole(RoleDTO role)
        {
            var voidResult = new VoidResult();
            var roleDto = _mapper.Map<Role>(role);

            var result =_repository.Update(roleDto);
            if (!result)
            {
                voidResult.Success = false;
                voidResult.Message = Messages.NotUpdated;
                return voidResult;
            }
            voidResult.Message = Messages.Updated;
            voidResult.Success = true;
            return voidResult;
        }
    }
}
