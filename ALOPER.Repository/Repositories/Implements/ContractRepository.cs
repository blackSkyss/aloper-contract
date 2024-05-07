using ALOPER.Repository.DBContext;
using ALOPER.Repository.Models;
using ALOPER.Repository.Repositories.Interfaces;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Contract = ALOPER.Repository.Models.Contract;

namespace ALOPER.Repository.Repositories.Implements
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        private AloperDbContext _dbContext;
        public ContractRepository(AloperDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contract?> GetContractById(string id)
        {
            return await _dbContext.Contracts
                                   .Include(c => c.Services)
                                   .Include(c => c.Furnitures)
                                   .FirstOrDefaultAsync(c => c.Id.ToLower().Equals(id.ToLower()));
        }
    }
}
