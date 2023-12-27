using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Requests
{
    public class UserRoleRequestDTO
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }


        public async Task<UserRole> ToModel(UserRoleRequestDTO request)
        {
            return await Task.FromResult<UserRole>(new UserRole
            {
               RoleId = request.RoleId,
               UserId = request.UserId,
            });
        }

        public async Task<UserRoleRequestDTO> ToRequest(UserRole usrl)
        {
            return await Task.FromResult<UserRoleRequestDTO>(new UserRoleRequestDTO
            {
                RoleId = usrl.RoleId,
                UserId = usrl.UserId,
            });
        }


    }
}
