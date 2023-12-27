using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class PermissionResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public virtual ICollection<PermissionRole>? PermissionRoles { get; set; }

        public async Task<PermissionResponseDTO> FromModel(Permission permi)
        {
            return await Task.FromResult<PermissionResponseDTO>(new PermissionResponseDTO
            {
                Id = permi.Id,
                Name = permi.Name,
                Description = permi.Description,
                PermissionRoles = permi.PermissionRoles,
            });
        }

        public async Task<List<PermissionResponseDTO>> FromModel(IEnumerable<Permission> permi)
        {

            List<PermissionResponseDTO> responses = new List<PermissionResponseDTO>();
            foreach (var item in permi)
            {
                var res = new PermissionResponseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    PermissionRoles=item.PermissionRoles,

                };

                responses.Add(res);
            }
            var list = new List<PermissionResponseDTO>();
            list.AddRange((IEnumerable<PermissionResponseDTO>)permi.Select((x) => FromModel(x)));
            return await Task.FromResult<List<PermissionResponseDTO>>(list);
        }

    }
}
