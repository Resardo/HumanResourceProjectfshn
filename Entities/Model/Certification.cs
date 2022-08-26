using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Certification
    {
        public Guid Id { get; set; }
        public string Providers { get; set; } = null!;
        public DateTime TakeDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technology { get; set; } = null!;
        public Guid? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
