using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Mapper.PermissionRoles
{
    public class AutoMappingPermissionRoleProfile:Profile
    {

        public AutoMappingPermissionRoleProfile()
        {
            CreateMap<PermissionRoleRequestDTO,PermissionRole>();
            CreateMap<PermissionRole,PermissionRoleResponseDTO>();
        }

    }
}
