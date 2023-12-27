using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;
using UserManagement_Domain.Common.Enums;

namespace UserManagement_Domain.Entities
{
    public class User: AuditableEntity
    {

        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserGroups = new HashSet<UserGroup>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }=string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(8,ErrorMessage ="You password must contains at least 8 digits")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public bool Gender { get; set; } =Convert.ToBoolean(GenderEnum.Female);

        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [Phone]
        public string PhoneNumber {  get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Passwords are not not matching ")]
        public string ConfirmPassword { get; set; } = null!;

        public bool State { get; set; } = false;

        [Required(ErrorMessage = "This field is required")]
        public string? Address { get; set; }
       
        public string ImageUrl {  get; set; }=null!;

        //[NotMapped]
        //public IFormFile? File { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get;set; }

        public int? Role_Id { get; set; }

        [ForeignKey(nameof(Role_Id))]
        [InverseProperty(nameof(Role.Users))]
        public ICollection<Role>? roles { get; set; }

        [InverseProperty(nameof(UserRole.user))]
        public virtual ICollection<UserRole> UserRoles { get; set; }



        [InverseProperty(nameof(UserGroup.user))]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }

}
