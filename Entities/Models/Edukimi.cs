using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Edukimi
    {
        public Guid Id { get; set; }
        public string Universitet { get; set; } = null!;
        public DateTime VitiNisjes { get; set; }
        public DateTime? VitiMbarimit { get; set; }
        public bool ProcesNdjekje { get; set; }
        public double Mesatarja { get; set; }
        public string ProfiliAkademik { get; set; } = null!;
        public string? TipiMasterit { get; set; }
        public Guid? IdPunonjesi { get; set; }
        public Guid? IdShkolle { get; set; }

        public virtual ShkollePunonje? IdNavigation { get; set; }
    }
}
