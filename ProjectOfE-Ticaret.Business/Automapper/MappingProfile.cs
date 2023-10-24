using AutoMapper;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.Business.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserInfoDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product,ProductInfoDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
