using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class PermissionRequestDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;


        public async Task<Permission> ToModel(PermissionRequestDTO request)
        {
            return await Task.FromResult<Permission>(new Permission
            {
                Name = request.Name,
                Description = request.Description,
            });
        }

        public async Task<PermissionRequestDTO> ToRequest(Permission permi)
        {
            return await Task.FromResult<PermissionRequestDTO>(new PermissionRequestDTO
            {
                Name = permi.Name,
                Description = permi.Description,
            });
        }
    }
}
