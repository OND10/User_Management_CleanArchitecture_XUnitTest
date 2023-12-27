using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.PermissionServices.Interface
{
    public interface IPermissionService
    {
        Task<IResponse<IEnumerable<PermissionResponseDTO>>> GetAllAsync();

        Task<IResponse<PermissionResponseDTO>> CreateAsync(PermissionRequestDTO model);

        Task<IResponse<PermissionResponseDTO>> UpdateAsync(PermissionRequestDTO model);

        Task<IResponse<PermissionRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(PermissionRequestDTO model);

    }
}
