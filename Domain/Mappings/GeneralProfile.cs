using AutoMapper;
using DTO.EducationDTO;
using DTO.LoginDTO;

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
        #region User
        public GeneralProfile()
        {
           CreateMap<Employee, LoginDTO>().ReverseMap();

            CreateMap<LoginCredentialsDTO, Employee>();/*.ForSourceMember (x => x.Password, opt => opt.DoNotValidate());*/
           CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<Employee, LoginDataDTO>().ReverseMap();



        }


        #endregion


    }
}
