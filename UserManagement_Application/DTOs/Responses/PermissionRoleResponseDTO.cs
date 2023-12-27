using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class PermissionRoleResponseDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public async Task<PermissionRoleResponseDTO> FromModel(PermissionRole perl)
        {
            return await Task.FromResult<PermissionRoleResponseDTO>(new PermissionRoleResponseDTO
            {
                Id = perl.Id,
                RoleId = perl.RoleId,
                PermissionId = perl.PermissionId
            });
        }

        public async Task<List<PermissionRoleResponseDTO>> FromModel(IEnumerable<PermissionRole> perl)
        {

            List<PermissionRoleResponseDTO> responses = new List<PermissionRoleResponseDTO>();
            foreach (var item in perl)
            {
                var res = new PermissionRoleResponseDTO
                {
                  Id=item.Id,
                  PermissionId = item.PermissionId,
                  RoleId = item.RoleId,
                };

                responses.Add(res);
            }
            var list = new List<PermissionRoleResponseDTO>();
            list.AddRange((IEnumerable<PermissionRoleResponseDTO>)perl.Select((x) => FromModel(x)));
            return await Task.FromResult<List<PermissionRoleResponseDTO>>(list);
        }
    }
}
