﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            Punonjes = new HashSet<Punonje>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Punonje> Punonjes { get; set; }
    }
}
