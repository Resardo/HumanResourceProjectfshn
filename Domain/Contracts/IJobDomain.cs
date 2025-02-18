﻿using DTO.JobDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IJobDomain
    {
        JobDTO GetJobById(Guid id);
        JobDTO Add(JobDTO job);
        void Update(JobDTO job);

        void Remove(Guid id);
    }
}
