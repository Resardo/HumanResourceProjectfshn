using DTO.EducationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IEducationDomain { 


         EducationDTO GetEducationById(Guid id);
         EducationDTO Add(EducationDTO education);
         void Update(EducationDTO education);

         void Remove(Guid id);

    }
}
