﻿using DTO.LoginDTO;
using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ILoginDomain
    {
       LoginDTO Auth(LoginCredentialsDTO dto);
        
    }
}
