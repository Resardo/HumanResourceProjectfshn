using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Archive
    {
        public Guid Id { get; set; }
        public string CardId { get; set; } = null!;
        public string Diploma { get; set; } = null!;
        public string RaportAftesie { get; set; } = null!;
        public Guid? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
