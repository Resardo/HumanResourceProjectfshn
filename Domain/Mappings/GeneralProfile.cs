using AutoMapper;
using DTO.ArchiveDTO;

using DTO.PermitDTO;
using DTO.RoleDTO;
using DTO.RoleDTO1;
using DTO.UserDTO;
using Entities.Model;
//using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        /*
        #region User
        public GeneralProfile()
        {
           CreateMap<User, UserDTO>().ReverseMap();

        }
        test commit

        #endregion

        */
        #region
        public GeneralProfile()
        {
           
            
            CreateMap<Role, RoleDTO1>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();



            CreateMap<Permit, PermitDTO>().ReverseMap();
          
            CreateMap<Archive, ArchiveDTO1>().ReverseMap();
            CreateMap<Archive, ArchiveDTO>().ReverseMap();
        }

#endregion

    }
}
