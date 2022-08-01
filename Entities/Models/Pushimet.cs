using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Pushimet
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Guid EmployeeId { get; set; }
        public byte[]? Raporti { get; set; }
        public string Tipi { get; set; } = null!;

        public virtual Punonje Employee { get; set; } = null!;
    }
}
