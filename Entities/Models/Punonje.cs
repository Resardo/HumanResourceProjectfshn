using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Punonje
    {
        public Punonje()
        {
            Arkivas = new HashSet<Arkiva>();
            Certifikimes = new HashSet<Certifikime>();
            Punesimes = new HashSet<Punesime>();
            Pushimets = new HashSet<Pushimet>();
            ShkollePunonjes = new HashSet<ShkollePunonje>();
            Projects = new HashSet<Projekte>();
            Roles = new HashSet<Role>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public string Pershkrimi { get; set; } = null!;
        public byte[] Fotoprofili { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Contact2 { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public DateTime DataArdhjes { get; set; }
        public DateTime? DataLargimit { get; set; }
        public string? ArsyeLargimi { get; set; }

        public virtual ICollection<Arkiva> Arkivas { get; set; }
        public virtual ICollection<Certifikime> Certifikimes { get; set; }
        public virtual ICollection<Punesime> Punesimes { get; set; }
        public virtual ICollection<Pushimet> Pushimets { get; set; }
        public virtual ICollection<ShkollePunonje> ShkollePunonjes { get; set; }

        public virtual ICollection<Projekte> Projects { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
