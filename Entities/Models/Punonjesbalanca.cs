using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Punonjesbalanca
    {
        public Guid? IdPunonjesi { get; set; }
        public double? Total { get; set; }

        public virtual Punonje? IdPunonjesiNavigation { get; set; }
    }
}
