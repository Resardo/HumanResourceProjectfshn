using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Certifications = new HashSet<Certification>();
            Jobs = new HashSet<Job>();
            Permits = new HashSet<Permit>();
            UserRoles = new HashSet<UserRole>();
            Educations = new HashSet<Education>();
            Projects = new HashSet<Project>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? EmailConfirm { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public string Descriptions { get; set; } = null!;
        public byte[] ProfilePhoto { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Contact2 { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public DateTime ComeDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string? LeaveReason { get; set; }
        public double DaysOffBalance { get; set; }

        public virtual Archive? Archive { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Permit> Permits { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
