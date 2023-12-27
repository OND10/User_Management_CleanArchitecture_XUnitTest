using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;

namespace UserManagement_Domain.Entities
{
    public class Permission: AuditableEntity
    {

        public Permission()
        {
            PermissionRoles = new HashSet<PermissionRole>();
        }
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public string Description { get; set; } = string.Empty;

        [InverseProperty(nameof(PermissionRole.permission))]
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
