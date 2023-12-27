using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class GroupRequestDTO
    {

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;


        public async Task<Group> ToModel(GroupRequestDTO request)
        {
            return await Task.FromResult<Group>(new Group
            {
                Name = request.Name,
                Description = request.Description,
            });
        }

        public async Task<GroupRequestDTO> ToRequest(Group group)
        {
            return await Task.FromResult<GroupRequestDTO>(new GroupRequestDTO
            {
                Name = group.Name,
                Description = group.Description,
            });
        }

    }
}
