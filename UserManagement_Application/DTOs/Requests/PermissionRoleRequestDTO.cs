using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class PermissionRoleRequestDTO
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public async Task<PermissionRole> ToModel(PermissionRoleRequestDTO request)
        {
            return await Task.FromResult<PermissionRole>(new PermissionRole
            {
                RoleId = request.RoleId,
                PermissionId = request.PermissionId
            });
        }

        public async Task<PermissionRoleRequestDTO> ToRequest(PermissionRole perl)
        {
            return await Task.FromResult<PermissionRoleRequestDTO>(new PermissionRoleRequestDTO
            {
                RoleId = perl.RoleId,
                PermissionId = perl.PermissionId
            });
        }
    }
}
