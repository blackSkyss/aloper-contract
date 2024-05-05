using ALOPER.Repository.DBContext;
using ALOPER.Repository.Models;
using ALOPER.Repository.Repositories.Interfaces;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Repositories.Implements
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private AloperDbContext _dbContext;
        public ServiceRepository(AloperDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Service?> GetServiceById(int id)
        {
            return await _dbContext.Services
                                   .Include(s => s.Contract)
                                   .FirstOrDefaultAsync(s => s.IdService == id);
        }

        public async Task RemoveServices(string id)
        {
            var services = await _dbContext.Services.Where(s => s.Contract.Id.ToLower().Equals(id.ToLower())).ToListAsync();
            _dbContext.Services.RemoveRange(services);
        }
    }
}
