using AutoMapper;
using DTO.UserDTO;
using Entities.Models;
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
