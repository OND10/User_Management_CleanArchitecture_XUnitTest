using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.PermissionServices.Interface;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services.PermissionServices.Implementation
{
    public class PermissionService : IPermissionService
    {

        public List<Permission> permis;
        private readonly IMapper _mapper;

        public PermissionService(IMapper mapper)
        {
            permis = new List<Permission>()
            {
                new Permission
                {
                   Id = 1,
                   Name = PermissionsEnum.Create.ToString(),
                   Description = "The ability to create many funds",
                   PermissionRoles = new List<PermissionRole>()
                   {
                       new PermissionRole
                       {
                         Id = 1,
                         PermissionId = 1,
                         RoleId = 1,
                       }
                   }
                },
                new Permission
                {
                   Id = 2,
                   Name = PermissionsEnum.Edit.ToString(),
                   Description = "The ability to update many funds",
                   PermissionRoles = new List<PermissionRole>()
                   {
                       new PermissionRole
                       {
                         Id = 2,
                         PermissionId = 2,
                         RoleId = 2,
                       }
                   }
                }
            };
            _mapper = mapper;
        }

        public async Task<IResponse<PermissionResponseDTO>> CreateAsync(PermissionRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<Permission>(model);
                permis.Add(domainmodel);
                var responsemodel = new PermissionResponseDTO();
                return await Response<PermissionResponseDTO>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in adding permissions");
            }
        }

        public async Task<IResponse> DeleteAsync(PermissionRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<Permission>(model);
                permis.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in deleting permissions");
            }
        }

        public async Task<IResponse<IEnumerable<PermissionResponseDTO>>> GetAllAsync()
        {
            try
            {
                var list = permis.ToList();
                var responsemodel = new PermissionResponseDTO();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<PermissionResponseDTO>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(permis), "Exception in returning permissions");
            }
        }

        public async Task<IResponse<PermissionRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = permis.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new PermissionRequestDTO();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<PermissionRequestDTO>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding permissions");
            }
        }

        public Task<IResponse<PermissionResponseDTO>> UpdateAsync(PermissionRequestDTO model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating permissions");
        }
    }
}
