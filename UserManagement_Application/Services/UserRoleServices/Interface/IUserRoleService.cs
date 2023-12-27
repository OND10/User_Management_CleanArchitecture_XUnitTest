using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.UserRoleServices.Interface
{
    public interface IUserRoleService
    {

        Task<IResponse<IEnumerable<UserRoleResponseDTO>>> GetAllAsync();

        Task<IResponse<UserRoleResponseDTO>> CreateAsync(UserRoleRequestDTO model);

        Task<IResponse<UserRoleResponseDTO>> UpdateAsync(UserRoleRequestDTO model);

        Task<IResponse<UserRoleRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(UserRoleRequestDTO model);

    }
}
