using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Certifikime
    {
        public Guid Id { get; set; }
        public string Provideri { get; set; } = null!;
        public DateTime DataFitimit { get; set; }
        public DateTime DataSkadences { get; set; }
        public string LinkimTeknologjie { get; set; } = null!;
        public Guid? PunonjesId { get; set; }

        public virtual Punonje? Punonjes { get; set; }
    }
}
