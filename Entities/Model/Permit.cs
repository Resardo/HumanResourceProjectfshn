using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Permit
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; } = null!;
        public string PermitType { get; set; } = null!;
        public Guid? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
