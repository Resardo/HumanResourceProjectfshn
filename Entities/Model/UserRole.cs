using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class UserRole
    {
        public Guid RoleId { get; set; }
        public Guid PunonjesId { get; set; }
        public DateTime? AssignedDate { get; set; }

        public virtual Employee Punonjes { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
