using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;

namespace UserManagement_Domain.Entities
{
    public class UserRole: AuditableEntity
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.UserRoles))]
        public User? user { get; set; }


        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Role.UserRoles))]
        public Role? role { get; set; }
    }
}
