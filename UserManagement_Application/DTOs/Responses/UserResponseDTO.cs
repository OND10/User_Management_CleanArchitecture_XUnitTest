using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class UserResponseDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = null!;

        public string PhoneNumber { get; set; } = string.Empty;

        public bool State { get; set; } = false;

        public string? Address { get; set; }

        public bool Gender { get; set; } = Convert.ToBoolean(GenderEnum.Female);

       

        public UserResponseDTO FromModel(User user)
        {
            return new UserResponseDTO 
            { 
                Id = user.Id, Name = user.Name, Email = user.Email, State = user.State, Address = user.Address,Gender = user.Gender, PhoneNumber = user.PhoneNumber,Username = user.Username,
            };
        }

        public async Task<List<UserResponseDTO>> FromModel(IEnumerable<User>user) {

            List<UserResponseDTO> responses=new List<UserResponseDTO>();
            foreach(var item in user)
            {
                var res = new UserResponseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    State = item.State,
                    Address = item.Address,
                    Gender = item.Gender,
                    PhoneNumber = item.PhoneNumber,
                    Username = item.Username,
                };
                responses.Add(res);
            }
            var list=new List<UserResponseDTO>();
            list.AddRange((IEnumerable<UserResponseDTO>)user.Select((x) => FromModel(x)));
            return await Task.FromResult<List<UserResponseDTO>>(list);
        
        }
    }
}
