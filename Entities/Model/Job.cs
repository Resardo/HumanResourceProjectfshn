using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Job
    {
        public Guid Id { get; set; }
        public string Company { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Descriptions { get; set; } = null!;
        public string ConfidencialityScale { get; set; } = null!;
        public Guid? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
