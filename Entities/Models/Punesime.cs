using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Punesime
    {
        public Guid Id { get; set; }
        public string Kompania { get; set; } = null!;
        public string Pozicioni { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Pershkrim { get; set; } = null!;
        public string ShkallaKonfidencialitetit { get; set; } = null!;
        public Guid? PunonjesId { get; set; }

        public virtual Punonje? Punonjes { get; set; }
    }
}
