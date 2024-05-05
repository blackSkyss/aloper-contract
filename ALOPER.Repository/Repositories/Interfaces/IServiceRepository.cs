using ALOPER.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<Service?> GetServiceById(int id);
        Task RemoveServices(string id);
    }
}
