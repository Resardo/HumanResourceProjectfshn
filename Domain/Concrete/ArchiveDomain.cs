using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.ArchiveDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class ArchiveDomain : DomainBase, IArchiveDomain
    {
        public ArchiveDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IArchiveRepository archiveRepository => _unitOfWork.GetRepository<IArchiveRepository>();


        public IList<ArchiveDTO1> GetAllArchives()
        {
            IEnumerable<Archive> archives = archiveRepository.GetAll();
            var test = _mapper.Map<IList<ArchiveDTO1>>(archives);

            return test;
        }
        public Archive CreateArchive(ArchiveDTO archive)


        {
            /*

            PermitDTO permit1 = new RoleDTO();
            permit1.RoleId = Guid.NewGuid();
            role1.Name = permit.Name;
            */

            var s = _mapper.Map<ArchiveDTO, Archive>(archive);
            archiveRepository.Add(s);
            return s;
        }

        public Archive GetById(Guid id)
        {
            var archive = archiveRepository.GetById(id);
            return archive;
        }
        public void Remove(Guid id)
        {
            archiveRepository.Remove(id);


        }
        public void Update(ArchiveDTO1 archive)
        {

            var p = _mapper.Map<ArchiveDTO1, Archive>(archive);
            archiveRepository.Update(p);
        }
    
}
}
