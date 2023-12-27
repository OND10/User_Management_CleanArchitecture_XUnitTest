using AutoMapper;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.Mapper
{
    public class AutoMappingUserProfile : Profile
    {
        public AutoMappingUserProfile()
        {
            CreateMap<UserRequestDTO,User>();
            CreateMap<User, UserResponseDTO>();
        }
    }
}
