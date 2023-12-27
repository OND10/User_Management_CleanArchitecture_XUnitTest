using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.UserGroupServices.Interface
{
    public interface IUserGroupService
    {

        Task<IResponse<IEnumerable<UserGroupResponseDTO>>> GetAllAsync();

        Task<IResponse<UserGroupResponseDTO>> CreateAsync(UserGroupRequestDTO model);

        Task<IResponse<UserGroupResponseDTO>> UpdateAsync(UserGroupRequestDTO model);

        Task<IResponse<UserGroupRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(UserGroupRequestDTO model);

    }
}
