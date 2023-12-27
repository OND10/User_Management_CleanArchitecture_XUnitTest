using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class GroupResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public virtual ICollection<UserGroup>? UserGroups { get; set; }


        public async Task<GroupResponseDTO> FromModel(Group group)
        {
            return await Task.FromResult<GroupResponseDTO>(new GroupResponseDTO
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                UserGroups = group.UserGroups,
            });
        }

        public async Task<List<GroupResponseDTO>> FromModel(IEnumerable<Group> group)
        {

            List<GroupResponseDTO> responses = new List<GroupResponseDTO>();
            foreach (var item in group)
            {
                var res = new GroupResponseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    UserGroups=item.UserGroups,

                };

                responses.Add(res);
            }
            var list = new List<GroupResponseDTO>();
            list.AddRange((IEnumerable<GroupResponseDTO>)group.Select((x) => FromModel(x)));
            return await Task.FromResult<List<GroupResponseDTO>>(list);

        }

    }
}
