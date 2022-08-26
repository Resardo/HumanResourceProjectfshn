using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ArchiveDTO
{
    public class ArchiveDTO1
    {


        public Guid Id { get; set; }
        public string CardId { get; set; } = null!;
        public string Diploma { get; set; } = null!;
        public string RaportAftesie { get; set; } = null!;
        public Guid? EmployeeId { get; set; }
    }
}
