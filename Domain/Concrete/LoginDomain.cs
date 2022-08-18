using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.LoginDTO;
using DTO.UserDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class LoginDomain : DomainBase, ILoginDomain
    {
        public LoginDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {

        }
        private ILoginRepository loginRepository => _unitOfWork.GetRepository<ILoginRepository>();

        public  LoginDTO GetAllUsers(LoginCredentialsDTO dto)
        {


            
            var data = _mapper.Map<LoginCredentialsDTO, Employee>(dto);
            var login = loginRepository.Generate(data);
            //var verify = VerifyPasswordHash(dto.Password, login.PasswordHash);
            //var test = System.Convert.ToBase64String(dto.Password);


            string str = Convert.ToBase64String(login.PasswordHash);

            byte[] data1 = Convert.FromBase64String(dto.Password);
            string decodedString = Encoding.UTF8.GetString(data1);
            //if (verify == true)
            //{
            //    var result = _mapper.Map<Employee, LoginDTO>(login);
            //        return result;
            // }
            return null;
            }
            
        

        public UserDTO GetUserById(Guid id)
        {
            Employee user = loginRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }


    }
}
