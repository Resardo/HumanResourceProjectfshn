using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Arkiva
    {
        public Guid Id { get; set; }
        public byte[] KartaId { get; set; } = null!;
        public byte[] Diploma { get; set; } = null!;
        public byte[] RaportAftesie { get; set; } = null!;
        public Guid? PunonjesId { get; set; }

        public virtual Punonje? Punonjes { get; set; }
    }
}
