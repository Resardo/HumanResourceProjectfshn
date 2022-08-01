using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Shkolla
    {
        public Shkolla()
        {
            ShkollePunonjes = new HashSet<ShkollePunonje>();
        }

        public Guid IdShkolle { get; set; }
        public string? Tipi { get; set; }
        public string? Emri { get; set; }

        public virtual ICollection<ShkollePunonje> ShkollePunonjes { get; set; }
    }
}
