using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.UserGroupServices.Interface;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services.UserGroupServices.Implementation
{
    public class UserGroupService : IUserGroupService
    {

        public List<UserGroup> usergroups;
        private readonly IMapper _mapper;

        public UserGroupService(IMapper mapper)
        {
            usergroups = new List<UserGroup>()
            {
                new UserGroup
                {
                    Id = 1,
                    UserId = 1,
                    GroupId = 1,
                },
                new UserGroup
                {
                    Id = 2,
                    UserId = 2,
                    GroupId = 2,
                }
            };
            _mapper = mapper;
        }
        public async Task<IResponse<UserGroupResponseDTO>> CreateAsync(UserGroupRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<UserGroup>(model);
                usergroups.Add(domainmodel);
                var responsemodel = new UserGroupResponseDTO();
                return await Response<UserGroupResponseDTO>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in adding usergroups");
            }
        }

        public async Task<IResponse> DeleteAsync(UserGroupRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<UserGroup>(model);
                usergroups.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in deleting usergroups");
            }
        }

        public async Task<IResponse<IEnumerable<UserGroupResponseDTO>>> GetAllAsync()
        {
            try
            {
                var list = usergroups.ToList();
                var responsemodel = new UserGroupResponseDTO();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<UserGroupResponseDTO>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(usergroups), "Exception in returning usergroups");
            }
        }

        public async Task<IResponse<UserGroupRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = usergroups.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new UserGroupRequestDTO();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<UserGroupRequestDTO>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding usergroups");
            }
        }

        public Task<IResponse<UserGroupResponseDTO>> UpdateAsync(UserGroupRequestDTO model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating roles");
        }
    }
}
