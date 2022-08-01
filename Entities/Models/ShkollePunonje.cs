using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ShkollePunonje
    {
        public ShkollePunonje()
        {
            Edukimis = new HashSet<Edukimi>();
        }

        public Guid PunonjesId { get; set; }
        public Guid IdShkolle { get; set; }

        public virtual Shkolla IdShkolleNavigation { get; set; } = null!;
        public virtual Punonje Punonjes { get; set; } = null!;
        public virtual ICollection<Edukimi> Edukimis { get; set; }
    }
}
