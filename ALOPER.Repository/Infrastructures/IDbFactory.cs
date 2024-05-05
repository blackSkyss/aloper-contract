using ALOPER.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Infrastructures
{
    public interface IDbFactory : IDisposable
    {
        public AloperDbContext InitDbContext();
    }
}
