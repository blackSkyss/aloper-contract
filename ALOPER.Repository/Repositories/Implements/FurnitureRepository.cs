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
    public class FurnitureRepository : RepositoryBase<Furniture>, IFurnitureRepository
    {

        private AloperDbContext _dbContext;
        public FurnitureRepository(AloperDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Furniture?> GetFurnitureById(int id)
        {
            return await _dbContext.Furnitures
                                   .Include(f => f.Contract)
                                   .FirstOrDefaultAsync(f => f.IdFurniture == id);
        }

        public async Task RemoveFurnites(string id)
        {
            var furnites =  await _dbContext.Furnitures.Where(f => f.Contract.Id.ToLower().Equals(id.ToLower())).ToListAsync();
            _dbContext.Furnitures.RemoveRange(furnites);
        }
    }
}
