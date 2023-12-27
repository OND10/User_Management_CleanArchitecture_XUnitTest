using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.RoleServices
{
    public interface IRoleService
    {

        Task<IResponse<IEnumerable<RoleResponseDTO>>> GetAllAsync();

        Task<IResponse<RoleResponseDTO>> CreateAsync(RoleRequestDTO model);

        Task<IResponse<RoleResponseDTO>> UpdateAsync(RoleRequestDTO model);

        Task<IResponse<RoleRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(RoleRequestDTO model);


    }
}
