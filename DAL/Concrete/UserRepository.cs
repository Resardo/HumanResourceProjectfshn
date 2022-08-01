using DAL.Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    internal class UserRepository : BaseRepository<Punonje, Guid>, IUserRepository
    {

        public UserRepository(HR1Context dbContext) : base(dbContext)
        {
        }

        public Punonje GetById(Guid id)
        {
            var user = context.Where(a => a.Id == id).FirstOrDefault();
            return user;
        }


    }


}
