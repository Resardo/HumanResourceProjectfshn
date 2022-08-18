using AutoMapper;
using DTO.LoginDTO;
using DTO.UserDTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        #region Employee
        public GeneralProfile()
        {
           CreateMap<Employee, LoginDTO>().ReverseMap();
           CreateMap<Employee, UserDTO>().ReverseMap();
            CreateMap<LoginCredentialsDTO, Employee>().ForSourceMember(x => x.Password, opt => opt.DoNotValidate());
           
            
        }

        #endregion
        

    }
}
