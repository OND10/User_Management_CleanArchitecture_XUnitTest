using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class UserGroupResponseDTO
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }


        public async Task<UserGroupResponseDTO> FromModel(UserGroup usgr)
        {
            return await Task.FromResult<UserGroupResponseDTO>(new UserGroupResponseDTO
            {
                Id = usgr.Id,
                UserId = usgr.UserId,
                GroupId = usgr.GroupId
            });
        }

        public async Task<List<UserGroupResponseDTO>> FromModel(IEnumerable<UserGroup> usgr)
        {

            List<UserGroupResponseDTO> responses = new List<UserGroupResponseDTO>();
            foreach (var item in usgr)
            {
                var res = new UserGroupResponseDTO
                {
                  Id=item.Id,
                  UserId=item.UserId,
                  GroupId=item.GroupId
                };

                responses.Add(res);
            }
            var list = new List<UserGroupResponseDTO>();
            list.AddRange((IEnumerable<UserGroupResponseDTO>)usgr.Select((x) => FromModel(x)));
            return await Task.FromResult<List<UserGroupResponseDTO>>(list);
        }
    }
}
