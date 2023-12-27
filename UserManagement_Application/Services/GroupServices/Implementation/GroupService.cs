using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services.GroupServices.Interface;
using UserManagement_Application.Utly;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Services.GroupServices.Implementation
{
    public class GroupService : IGroupService
    {

        public List<Group> groups;
        private readonly IMapper _mapper;
        public GroupService(IMapper mapper)
        {
            groups = new List<Group>()
            {
                new Group
                {
                    Id = 1,
                    Name = "SupervisonGroup",
                    Description = "Menitoring employees who recently got employeed",
                    UserGroups= new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=1,
                            UserId=1,
                            GroupId=1,
                        }
                    }
                },
                new Group
                {
                    Id = 2,
                    Name = "TestingGroup",
                    Description = "Test and Deploy Software",
                    UserGroups= new List<UserGroup>()
                    {
                        new UserGroup
                        {
                            Id=2,
                            UserId=2,
                            GroupId=2,
                        }
                    }
                }
            };
            _mapper = mapper;
        }

        public async Task<IResponse<IEnumerable<GroupResponseDTO>>> GetAllAsync()
        {
            try
            {
                var list = groups.ToList();
                var responsemodel = new GroupResponseDTO();
                var converted = await responsemodel.FromModel(list);
                return await Response<IEnumerable<GroupResponseDTO>>.SuccessAsync(converted, "Viewd Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(groups), "Exception in returning groups");
            }
        }

        public async Task<IResponse<GroupResponseDTO>> CreateAsync(GroupRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<Group>(model);
                groups.Add(domainmodel);
                var responsemodel = new GroupResponseDTO();
                return await Response<GroupResponseDTO>.SuccessAsync(await responsemodel.FromModel(domainmodel), "Added Successfully");
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Exception in adding groups");
            }
        }

        public Task<IResponse<GroupResponseDTO>> UpdateAsync(GroupRequestDTO model)
        {
            throw new ModelNullException(nameof(model), "Exception in updating groups");
        }

        public async Task<IResponse<GroupRequestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var find = groups.FirstOrDefault(r => r.Id == id);
                if (find == null)
                {
                    throw new IdNullException("Exception : Id is Null");
                }
                else
                {
                    var requestmodel = new GroupRequestDTO();
                    var findrequest = await requestmodel.ToRequest(find);
                    return await Response<GroupRequestDTO>.SuccessAsync(findrequest, "");
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(id), "Exception in finding groups");
            }
        }

        public async Task<IResponse> DeleteAsync(GroupRequestDTO model)
        {
            try
            {
                var domainmodel = _mapper.Map<Group>(model);
                groups.Remove(domainmodel);
                return await Response.SuccessAsync();
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(groups), "Exception in deleting groups");
            }
        }
    }
}
