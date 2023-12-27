using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common;

namespace UserManagement_Domain.Entities
{
    public class Group:AuditableEntity
    {

        public Group()
        {
            UserGroups = new HashSet<UserGroup>(); 
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;


        [InverseProperty(nameof(UserGroup.group))]
        public virtual ICollection<UserGroup> UserGroups { get; set; }

    }
}
