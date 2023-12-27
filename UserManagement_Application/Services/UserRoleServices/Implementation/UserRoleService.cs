using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.UserRoleServices.Interface;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services.UserRoleServices.Implementation
{
    public class UserRoleService : IUserRoleService
    {

        public List<UserRole> userroles;
        private readonly IMapper _mapper;

        public UserRoleService(IMapper mapper)
        {
            userroles = new List<UserRole>()
            {
                new UserRole
                {
                   Id = 1,
                   UserId = 1,
                   RoleId = 1,
                },
                new UserRole
                {
                   Id = 2,
                   UserId = 2,
                   RoleId = 2,
                }
            };
            _mapper = mapper;
        }
        public async Task<IResponse<UserRoleResponseDTO>> CreateAsync(UserRoleRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<UserRole>(model);
                userroles.Add(domainmodel);
                var responsemodel = new UserRoleResponseDTO();
                return await Response<UserRoleResponseDTO>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in adding userroles");
            }
        }

        public async Task<IResponse> DeleteAsync(UserRoleRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<UserRole>(model);
                userroles.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in deleting userroles");
            }
        }

        public async Task<IResponse<IEnumerable<UserRoleResponseDTO>>> GetAllAsync()
        {
            try
            {
                var list = userroles.ToList();
                var responsemodel = new UserRoleResponseDTO();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<UserRoleResponseDTO>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(userroles), "Exception in returning userroles");
            }
        }

        public async Task<IResponse<UserRoleRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = userroles.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new UserRoleRequestDTO();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<UserRoleRequestDTO>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding userroles");
            }
        }

        public Task<IResponse<UserRoleResponseDTO>> UpdateAsync(UserRoleRequestDTO model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating userroles");
        }
    }
}
