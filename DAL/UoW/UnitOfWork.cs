using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Lamar;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContainer _container;

        private readonly HR1Context _context;

        public UnitOfWork(IContainer container, HR1Context context)
        {
            _container = container;
            _context = context;
            
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _container.GetInstance<TRepository>();
        }

        public int Save()
        {
            return _context.SaveChanges();
           
        }

        public void Dispose()
        {
            //_context.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
