using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Mapper
{
    public class AutoMappingRoleProfile:Profile
    {

        public AutoMappingRoleProfile()
        {
            CreateMap<RoleRequestDTO, Role>();
            CreateMap<Role, RoleResponseDTO>();
        }

    }
}
