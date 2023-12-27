using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.PermissionRoleServices.Interface
{
    public interface IPermissionRoleService
    {
        Task<IResponse<IEnumerable<PermissionRoleResponseDTO>>> GetAllAsync();

        Task<IResponse<PermissionRoleResponseDTO>> CreateAsync(PermissionRoleRequestDTO model);

        Task<IResponse<PermissionRoleResponseDTO>> UpdateAsync(PermissionRoleRequestDTO model);

        Task<IResponse<PermissionRoleRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(PermissionRoleRequestDTO model);

    }
}
