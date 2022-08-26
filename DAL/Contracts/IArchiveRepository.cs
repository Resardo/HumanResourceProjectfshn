using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IArchiveRepository : IRepository<Archive, Guid>
    {
        Archive GetByEmployeeId(Guid id);
        Archive GetById(Guid id);
        Archive Add(Archive archive);
        void Update(Archive archive);
        void Remove(Guid id);

    }
}
