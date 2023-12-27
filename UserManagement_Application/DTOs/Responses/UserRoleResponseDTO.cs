using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class UserRoleResponseDTO
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        public async Task<UserRoleResponseDTO> FromModel(UserRole usrl)
        {
            return await Task.FromResult<UserRoleResponseDTO>(new UserRoleResponseDTO
            {
                Id = usrl.Id,
                RoleId = usrl.RoleId,
                UserId = usrl.UserId,
            });
        }

        public async Task<List<UserRoleResponseDTO>> FromModel(IEnumerable<UserRole> usrl)
        {

            List<UserRoleResponseDTO> responses = new List<UserRoleResponseDTO>();
            foreach (var item in usrl)
            {
                var res = new UserRoleResponseDTO
                {
                    Id = item.Id,
                   RoleId=item.RoleId,
                   UserId=item.UserId,
                };

                responses.Add(res);
            }
            var list = new List<UserRoleResponseDTO>();
            list.AddRange((IEnumerable<UserRoleResponseDTO>)usrl.Select((x) => FromModel(x)));
            return await Task.FromResult<List<UserRoleResponseDTO>>(list);
        }
    }
}
