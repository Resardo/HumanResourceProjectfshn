using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Education
    {
        public Education()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string University { get; set; } = null!;
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public bool IsFollowing { get; set; }
        public double Average { get; set; }
        public string AcademicProfile { get; set; } = null!;
        public string? MasterType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
