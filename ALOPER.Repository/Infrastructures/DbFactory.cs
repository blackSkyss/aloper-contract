using ALOPER.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AloperDbContext _dbContext;

        public DbFactory()
        {

        }
        public AloperDbContext InitDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new AloperDbContext();
            }
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
