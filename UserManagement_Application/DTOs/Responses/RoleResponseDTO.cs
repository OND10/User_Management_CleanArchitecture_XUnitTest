using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Entities;

namespace UserManagement_Application.DTOs.Responses
{
    public class RoleResponseDTO
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Role Name")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        [InverseProperty(nameof(User.roles))]
        public ICollection<User>? Users { get; set; }



        public async Task<RoleResponseDTO> FromModel(Role role)
        {
            return await Task.FromResult<RoleResponseDTO>(new RoleResponseDTO 
            { 
                Id=role.Id,
                Name=role.Name,
                Description=role.Description,
                Users=role.Users,
            });
        }

        public async Task<List<RoleResponseDTO>> FromModel(IEnumerable<Role> role)
        {

            List<RoleResponseDTO> responses = new List<RoleResponseDTO>();
            foreach (var item in role)
            {
                var res = new RoleResponseDTO
                {
                    Id = item.Id,
                    Name=item.Name,
                    Description=item.Description,
                    Users=item.Users,

                };

                responses.Add(res);
            }
            var list = new  List<RoleResponseDTO>();
            list.AddRange((IEnumerable<RoleResponseDTO>)role.Select((x) => FromModel(x)));
            return await Task.FromResult<List<RoleResponseDTO>>(list);

        }

    }
}
