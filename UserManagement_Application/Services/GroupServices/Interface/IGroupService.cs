using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Utly;

namespace UserManagement_Application.Services.GroupServices.Interface
{
    public interface IGroupService
    {
        Task<IResponse<IEnumerable<GroupResponseDTO>>> GetAllAsync();

        Task<IResponse<GroupResponseDTO>> CreateAsync(GroupRequestDTO model);

        Task<IResponse<GroupResponseDTO>> UpdateAsync(GroupRequestDTO model);

        Task<IResponse<GroupRequestDTO>> GetByIdAsync(int id);

        Task<IResponse> DeleteAsync(GroupRequestDTO model);


    }
}
