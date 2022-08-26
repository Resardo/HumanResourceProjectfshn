using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
