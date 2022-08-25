using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
//using DAL.Concrete;
using DAL.Contracts;
using Lamar;

namespace DAL.DI
{
    public class RepositoryRegistry : ServiceRegistry
    {
        public RepositoryRegistry()
        {
            IncludeRegistry<UnitOfWorkRegistry>();

         

          

            For<IRolesRepository>().Use<RoleRepository>();

            For<IPermitRepository>().Use<PermitRepository>();


           

            For<IArchiveRepository>().Use<ArchiveRepository>();
            For<ILoginRepository>().Use<LoginRepository>();
            For<IEducationRepository>().Use<EducationRepository>();
            For<IJobRepository>().Use<JobRepository>();
            // For<IUserRepository>().Use<UserRepository>();
        }


    }
}
