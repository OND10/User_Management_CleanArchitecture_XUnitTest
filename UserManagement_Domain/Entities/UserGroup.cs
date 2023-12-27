using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;

namespace UserManagement_Domain.Entities
{
    public class UserGroup: AuditableEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.UserGroups))]
        public User? user { get; set; }


        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(Group.UserGroups))]
        public Group? group { get; set; }


    }
}
