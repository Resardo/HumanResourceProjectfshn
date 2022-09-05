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

        public LoginDTO Auth(LoginCredentialsDTO dto)
        {



            var data = _mapper.Map<LoginCredentialsDTO, Employee>(dto);
            var login = loginRepository.Generate(data);
            var role = login.UserRoles.FirstOrDefault().ToList();
            if (login == null) { return null; }
            else
            {
                string passwordStr = Convert.ToBase64String(login.PasswordHash);
                var passChanged = passwordStr.Remove(8, 1).Insert(8, "B");
                string[] pass = passChanged.Split("B");
                string pass1 = pass[0];


                if (pass1.Equals(dto.Password))
                {
                    var result = _mapper.Map<Employee, LoginDTO>(login);
                    result.Role = role;
                    return result;
                }
                return null;
            }
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

            //    for (int i = 0; i < computedHash.Length; i++)
            //    {
            //        if (computedHash[i] != passwordHash[i])
            //        {

            //            return false;
            //        }
            //    }
            //    return true;
            
            return computedHash.SequenceEqual(passwordHash);
            }
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


    }
}
