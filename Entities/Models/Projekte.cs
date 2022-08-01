using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Projekte
    {
        public Projekte()
        {
            Punonjes = new HashSet<Punonje>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual ICollection<Punonje> Punonjes { get; set; }
    }
}
