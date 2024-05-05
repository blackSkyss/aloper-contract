using ALOPER.Repository.DBContext;
using ALOPER.Repository.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private AloperDbContext _dbContext;
        private ContractRepository _contractRepository;
        private ServiceRepository _serviceRepository;
        private FurnitureRepository _furnitureRepository;

        public UnitOfWork(IDbFactory dbFactory)
        {
            if (_dbContext == null)
            {
                _dbContext = dbFactory.InitDbContext();
            }
        }

        public ContractRepository ContractRepository
        {
            get
            {
                if (_contractRepository == null)
                {
                    _contractRepository = new ContractRepository(_dbContext);
                }
                return _contractRepository;
            }
        }

        public ServiceRepository ServiceRepository
        {
            get
            {
                if (_serviceRepository == null)
                {
                    _serviceRepository = new ServiceRepository(_dbContext);
                }
                return _serviceRepository;
            }
        }


        public FurnitureRepository FurnitureRepository
        {
            get
            {
                if (_furnitureRepository == null)
                {
                    _furnitureRepository = new FurnitureRepository(_dbContext);
                }
                return _furnitureRepository;
            }
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
