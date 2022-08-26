using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IPermitRepository : IRepository<Permit, Guid>
    {

        Permit GetByEmployeeId(Guid id);
        Permit GetById(Guid id);
        Permit Add(Permit permit);
        void Update(Permit permit);
        void Remove(Guid id);
    }
}
