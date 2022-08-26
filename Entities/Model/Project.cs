using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string Names { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
