using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Infrastructures
{
    public interface IUnitOfWork
    {
        public void SaveChange();
        public Task SaveChangesAsync();
    }
}
