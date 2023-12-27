using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class UserGroupRequestDTO
    {
        public int UserId { get; set; }

        public int GroupId { get; set; }


        public async Task<UserGroup> ToModel(UserGroupRequestDTO request)
        {
            return await Task.FromResult<UserGroup>(new UserGroup
            {
                UserId = request.UserId,
                GroupId = request.GroupId,
            });
        }

        public async Task<UserGroupRequestDTO> ToRequest(UserGroup usgr)
        {
            return await Task.FromResult<UserGroupRequestDTO>(new UserGroupRequestDTO
            {
                UserId=usgr.UserId,
                GroupId = usgr.GroupId, 
            });
        }
    }
}
