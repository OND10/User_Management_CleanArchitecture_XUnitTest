using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.PermissionRoleServices.Interface;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services.PermissionRoleServices.Implementation
{
    internal class PermissionRoleService : IPermissionRoleService
    {

        public List<PermissionRole> perroles;
        private readonly IMapper _mapper;
        public PermissionRoleService(IMapper mapper)
        {
            perroles = new List<PermissionRole>()
            {
                new PermissionRole
                {
                    Id = 1,
                    PermissionId = 1,
                    RoleId = 1,
                },
                new PermissionRole
                {
                    Id = 2,
                    PermissionId = 2,
                    RoleId = 2,
                }
            };
            _mapper = mapper;
        }
        public async Task<IResponse<PermissionRoleResponseDTO>> CreateAsync(PermissionRoleRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<PermissionRole>(model);
                perroles.Add(domainmodel);
                var responsemodel = new PermissionRoleResponseDTO();
                return await Response<PermissionRoleResponseDTO>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in adding permissionroles");
            }
        }

        public async Task<IResponse> DeleteAsync(PermissionRoleRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<PermissionRole>(model);
                perroles.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in deleting permissionroles");
            }
        }

        public async Task<IResponse<IEnumerable<PermissionRoleResponseDTO>>> GetAllAsync()
        {
            try
            {
                var list = perroles.ToList();
                var responsemodel = new PermissionRoleResponseDTO();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<PermissionRoleResponseDTO>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(perroles), "Exception in returning permissionroles");
            }
        }

        public async Task<IResponse<PermissionRoleRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = perroles.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new PermissionRoleRequestDTO();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<PermissionRoleRequestDTO>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding permissionroles");
            }
        }

        public Task<IResponse<PermissionRoleResponseDTO>> UpdateAsync(PermissionRoleRequestDTO model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating permissionroles");
        }
    }
}
